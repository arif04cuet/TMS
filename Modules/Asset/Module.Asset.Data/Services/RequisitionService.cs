using Dapper;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Module.Core.Data;
using Module.Core.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class RequisitionService : IRequisitionService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Requisition> _requisitionRepository;
        private readonly IRepository<RequisitionItem> _requisitionItemRepository;
        private readonly IRepository<RequisitionHistory> _requisitionHistoryRepository;
        private readonly IRepository<RequisitionHistoryItem> _requisitionHistoryItemRepository;
        private readonly IDbConnection _dbConnection;
        private readonly IAppService _appService;

        public RequisitionService(
            IUnitOfWork unitOfWork,
            IAppService appService)
        {
            _unitOfWork = unitOfWork;
            _appService = appService;
            _dbConnection = _unitOfWork.GetConnection();
            _requisitionRepository = _unitOfWork.GetRepository<Requisition>();
            _requisitionItemRepository = _unitOfWork.GetRepository<RequisitionItem>();
            _requisitionHistoryRepository = _unitOfWork.GetRepository<RequisitionHistory>();
            _requisitionHistoryItemRepository = _unitOfWork.GetRepository<RequisitionHistoryItem>();
        }

        public async Task<long> CreateAsync(RequisitionCreateRequest request, CancellationToken cancellationToken = default)
        {
            var requisition = request.Map();

            long? loggedInUserId = _appService.GetAuthenticatedUser()?.Id;
            if (!loggedInUserId.HasValue || loggedInUserId.Value <= 0)
                throw new ValidationException("Logged in user not found");

            requisition.InitiatorId = loggedInUserId.Value;
            requisition.Status = RequisitionStatus.Initiated;

            if (requisition.CurrentApproverId == null)
            {
                // currenct approver is null, set role
                requisition.CurrentRoleApproverId = RoleConstants.InventoryManager;
            }

            await _requisitionRepository.AddAsync(requisition, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var items = request.Items.Select(x =>
           {
               var item = x.Map();
               item.RequisitionId = requisition.Id;
               return item;
           });
            await _requisitionItemRepository.AddRangeAsync(items);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }

        public async Task<long> ApproveAsync(RequisitionStatusChangeRequest request, CancellationToken cancellationToken = default)
        {

            long? loggedInUserId = _appService.GetAuthenticatedUser()?.Id;
            if (!loggedInUserId.HasValue || loggedInUserId.Value <= 0)
                throw new ValidationException("Logged in user not found");

            var requisition = await _requisitionRepository
                .Where(x => x.Id == request.Requisition && !x.IsDeleted)
                .Include(x => x.Items)
                .FirstOrDefaultAsync(cancellationToken);

            if (requisition == null)
                throw new ValidationException("Requisition not found.");

            long? loggedInUserRoleId = await GetLoggedInUserRoleId();
            long? requisitionUserRoleId = await GetUserRoleId(requisition.CurrentApproverId);

            bool canStatusChange = loggedInUserId == requisition.CurrentApproverId || loggedInUserRoleId == requisition.CurrentRoleApproverId;

            if (!canStatusChange)
                throw new ValidationException("You have no rights to do this operation.");

            bool canApprove = canStatusChange && loggedInUserRoleId == RoleConstants.InventoryManager && request.Status == RequisitionStatus.Approved;

            if (!canApprove)
                throw new ValidationException("You have no rights to approve this requisition");

            // create history
            var history = Requisition.MapHistory(requisition);
            await _requisitionHistoryRepository.AddAsync(history);
            var result = await _unitOfWork.SaveChangesAsync();

            var historyItems = requisition.Items.Select(x => new RequisitionHistoryItem
            {
                AssetId = x.AssetId,
                AssetType = x.AssetType,
                Quantity = x.Quantity,
                Comment = x.Comment,
                RequisitionHistoryId = history.Id,
                RequisitionId = requisition.Id
            });
            await _requisitionHistoryItemRepository.AddRangeAsync(historyItems);

            // delete requisition items
            var requestItemIds = request.Items.Where(x => x.Id.HasValue).Select(x => x.Id);
            var itemsToBeDeleted = _requisitionItemRepository.Where(x => x.RequisitionId == requisition.Id && !requestItemIds.Contains(x.Id));
            _requisitionItemRepository.RemoveRange(itemsToBeDeleted);
            await _unitOfWork.SaveChangesAsync();

            // update requisition
            foreach (var item in request.Items)
            {
                var dbItem = await _requisitionItemRepository.FirstOrDefaultAsync(x => x.Id == item.Id && !x.IsDeleted);
                if (dbItem != null)
                {
                    // update
                    dbItem.Comment = item.Comment;
                    dbItem.Quantity = item.Quantity;
                }
                else
                {
                    // create
                    var newItem = item.Map();
                    newItem.RequisitionId = requisition.Id;
                    await _requisitionItemRepository.AddAsync(newItem);
                }
            }

            if (request.Status == RequisitionStatus.TemporaryApproved)
            {
                requisition.CurrentApproverId = null;
                requisition.CurrentRoleApproverId = RoleConstants.InventoryManager;
                requisition.Status = RequisitionStatus.TemporaryApproved;
            }
            else if (request.Status == RequisitionStatus.Rejected || request.Status == RequisitionStatus.Approved)
            {
                requisition.CurrentApproverId = null;
                requisition.CurrentRoleApproverId = null;
                requisition.Status = request.Status;
            }

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }

        public async Task<bool> UpdateAsync(RequisitionUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _requisitionRepository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Requisition not found");

            if (entity.Status != RequisitionStatus.Initiated)
                throw new NotFoundException($"Only initiated status requisition can be edited");

            entity = request.Map(entity);

            if (entity.CurrentApproverId == null)
            {
                // currenct approver is null, set role
                entity.CurrentRoleApproverId = RoleConstants.InventoryManager;
            }

            // delete requisition items
            var requestItemIds = request.Items.Where(x => x.Id.HasValue).Select(x => x.Id);
            var itemsToBeDeleted = _requisitionItemRepository.Where(x => x.RequisitionId == entity.Id && !requestItemIds.Contains(x.Id));
            _requisitionItemRepository.RemoveRange(itemsToBeDeleted);
            await _unitOfWork.SaveChangesAsync();

            foreach (var item in request.Items)
            {
                if (item.Id.HasValue)
                {
                    // update
                    var dbItem = await _requisitionItemRepository.Where(x => x.Id == item.Id && !x.IsDeleted).FirstOrDefaultAsync();
                    if (dbItem != null)
                    {
                        item.Map(dbItem);
                    }
                }
                else
                {
                    var newItem = item.Map();
                    newItem.RequisitionId = entity.Id;
                    await _requisitionItemRepository.AddAsync(newItem);
                }
            }

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _requisitionRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Requisition not found");

            if (entity.Status != RequisitionStatus.Initiated)
                throw new NotFoundException($"Only initiated status requisition can be deleted");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<RequisitionViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var requisition = await _requisitionRepository
                .AsReadOnly()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(RequisitionViewModel.Select())
                .FirstOrDefaultAsync(cancellationToken);

            if (requisition == null)
                throw new NotFoundException("Requisition not found");

            foreach (var item in requisition.Items)
            {
                int available = 0;
                string name = "";
                if (item.AssetType.Id == (long)AssetType.Asset)
                {
                    var asset = await _unitOfWork.GetRepository<Entities.Asset>()
                        .FirstOrDefaultAsync(x => x.Id == item.Asset.Id && x.CheckoutId == null && !x.IsDeleted, true);
                    available = asset != null ? 1 : 0;
                    name = asset?.Name ?? "";
                }
                else if (item.AssetType.Id == (long)AssetType.License)
                {
                    var license = await _unitOfWork.GetRepository<License>()
                        .FirstOrDefaultAsync(x => x.Id == item.Asset.Id && !x.IsDeleted, true);
                    available = license == null ? 0 : license.Available.Value;
                    name = license?.Name ?? "";
                }
                else if (item.AssetType.Id == (long)AssetType.Consumable)
                {
                    string sql = $@"with cte 
                        as (select c.ItemCodeId,
                        sum(c.Available) Available
                        from [asset].[Consumable] c
                        where c.IsDeleted = 0 and c.ItemCodeId = {item.Asset.Id}
                        group by c.ItemCodeId
                        )
                        select top 1 cte.Available Id, concat(i.Code, ' - ', i.Name) Name from cte
                        left join [asset].[ItemCode] i on i.Id = cte.ItemCodeId";
                    var asset = await _dbConnection.QueryFirstOrDefaultAsync<IdNameViewModel>(sql);

                    available = asset == null ? 0 : (int)asset.Id;
                    name = asset?.Name ?? "";
                }
                item.Available = available;
                item.Asset.Name = name;
            }

            return requisition;
        }

        public async Task<PagedCollection<RequisitionListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {

            long? loggedInUserId = _appService.GetAuthenticatedUser()?.Id;
            long? loggedInUserRoleId = await GetLoggedInUserRoleId();

            Expression<Func<Requisition, bool>> predicate = x => (x.InitiatorId == loggedInUserId
            || (x.CurrentApproverId == loggedInUserId && x.CurrentApproverId != null)
            || x.CurrentRoleApproverId == loggedInUserRoleId && x.CurrentRoleApproverId != null)
            && !x.IsDeleted;

            return await _requisitionRepository.ListAsync(predicate, RequisitionListViewModel.Select(loggedInUserId, loggedInUserRoleId), pagingOptions, searchOptions, cancellationToken);
        }

        private async Task<long?> GetLoggedInUserRoleId()
        {
            long? loggedInUserId = _appService.GetAuthenticatedUser()?.Id;
            var userRole = await _unitOfWork.GetRepository<UserRole>().FirstOrDefaultAsync(x => x.Id == loggedInUserId && !x.IsDeleted, true);
            return userRole?.Id;
        }

        private async Task<long?> GetUserRoleId(long? userId)
        {
            var userRole = await _unitOfWork.GetRepository<UserRole>().FirstOrDefaultAsync(x => x.Id == userId && !x.IsDeleted, true);
            return userRole?.Id;
        }

    }
}
