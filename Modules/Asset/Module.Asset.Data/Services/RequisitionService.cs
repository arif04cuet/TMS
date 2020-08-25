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
        private readonly IAssetService _assetService;
        private readonly ILicenseService _licenseService;
        private readonly IConsumableService _consumableService;

        public RequisitionService(
            IUnitOfWork unitOfWork,
            IAppService appService,
            IAssetService assetService,
            ILicenseService licenseService,
            IConsumableService consumableService)
        {
            _unitOfWork = unitOfWork;
            _appService = appService;
            _assetService = assetService;
            _licenseService = licenseService;
            _consumableService = consumableService;
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

        public async Task<long> ChangeStatusAsync(RequisitionStatusChangeRequest request, CancellationToken cancellationToken = default)
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

            long? currentRoleApproverId = requisition.CurrentRoleApproverId;
            long[] loggedInUserRoleIds = await GetLoggedInUserRoleIds();
            long[] requisitionUserRoleIds = await GetUserRoleIds(requisition.CurrentApproverId);
            bool isInventoryManager = loggedInUserRoleIds.Contains(RoleConstants.InventoryManager);

            bool canStatusChange = loggedInUserId == requisition.CurrentApproverId || loggedInUserRoleIds.Contains(requisition.CurrentRoleApproverId.Value);

            if (!canStatusChange)
                throw new ValidationException("You have no rights to do this operation.");

            if (request.Status == RequisitionStatus.Approved)
            {
                bool canApprove = canStatusChange && isInventoryManager;
                if (!canApprove)
                    throw new ValidationException("Only inventory manager can approve requisitions.");
            }

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

                if (request.Status == RequisitionStatus.Approved && isInventoryManager)
                {
                    // reduce asset
                    if (item.Type == AssetType.Asset)
                    {
                        await _assetService.CheckoutAsync(new AssetCheckoutRequest
                        {
                            AssetIds = new long[] { item.Asset },
                            ChekoutToUserId = requisition.InitiatorId
                        }, cancellationToken);
                    }
                    else if (item.Type == AssetType.License)
                    {
                        for (int i = 0; i < item.Quantity; i++)
                        {
                            await _licenseService.CheckoutAsync(new LicenseCheckoutRequest
                            {
                                Id = item.Asset,
                                IssuedToUserId = requisition.InitiatorId
                            }, cancellationToken);
                        }
                    }
                    else if (item.Type == AssetType.Consumable)
                    {
                        await _consumableService.CheckoutByItemCodeAsync(new ConsumableCheckoutByItemCodeRequest
                        {
                            ItemCodeId = item.Asset,
                            UserId = requisition.InitiatorId,
                            Quantity = item.Quantity
                        }, cancellationToken);
                    }
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

            if(request.Status == RequisitionStatus.Approved)
            {
                // create history
                var history2 = new RequisitionHistory
                {
                    ApproverId = loggedInUserId,
                    RoleApproverId = currentRoleApproverId,
                    BatchScheduleId = requisition.BatchScheduleId,
                    InitiatorId = requisition.InitiatorId,
                    RequisitionId = requisition.Id,
                    Status = RequisitionStatus.Approved,
                    Title = requisition.Title
                };
                await _requisitionHistoryRepository.AddAsync(history2);
                result += await _unitOfWork.SaveChangesAsync();

                var historyItems2 = request.Items.Select(x => new RequisitionHistoryItem
                {
                    AssetId = x.Asset,
                    AssetType = x.Type,
                    Quantity = x.Quantity,
                    Comment = x.Comment,
                    RequisitionHistoryId = history2.Id,
                    RequisitionId = requisition.Id
                });
                await _requisitionHistoryItemRepository.AddRangeAsync(historyItems2);
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
            long? loggedInUserId = _appService.GetAuthenticatedUser()?.Id;
            long[] loggedInUserRoleIds = await GetLoggedInUserRoleIds();
            bool isInventoryManager = loggedInUserRoleIds.Contains(RoleConstants.InventoryManager);

            var requisition = await _requisitionRepository
                .GetAsync(x => x.Id == id, RequisitionViewModel.Select(loggedInUserId, loggedInUserRoleIds, isInventoryManager));

            if (requisition == null)
                throw new NotFoundException("Requisition not found");

            foreach (var item in requisition.Items)
            {
                int available = 0;
                string name = "";
                if (item.AssetType.Id == (long)AssetType.Asset)
                {
                    var asset = await _unitOfWork.GetRepository<Entities.Asset>()
                        .FirstOrDefaultAsync(x => x.Id == item.Asset.Id && !x.IsDeleted, true);
                    available = asset != null && asset.CheckoutId == null ? 1 : 0;
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
                    var asset = await GetConsumable(item.Asset.Id);
                    available = (int)asset.Id;
                    name = asset.Name;
                }
                item.Available = available;
                item.Asset.Name = name;
            }

            foreach (var item in requisition.Histories.SelectMany(x => x.Items))
            {
                string name = "";
                if (item.AssetType.Id == (long)AssetType.Asset)
                {
                    var asset = await _unitOfWork.GetRepository<Entities.Asset>()
                        .FirstOrDefaultAsync(x => x.Id == item.Asset.Id && !x.IsDeleted, true);
                    name = asset?.Name ?? "";
                }
                else if (item.AssetType.Id == (long)AssetType.License)
                {
                    var license = await _unitOfWork.GetRepository<License>()
                        .FirstOrDefaultAsync(x => x.Id == item.Asset.Id && !x.IsDeleted, true);
                    name = license?.Name ?? "";
                }
                else if (item.AssetType.Id == (long)AssetType.Consumable)
                {
                    var asset = await GetConsumable(item.Asset.Id);
                    name = asset.Name;
                }
                item.Asset.Name = name;
            }

            return requisition;
        }

        public async Task<PagedCollection<RequisitionListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {

            long? loggedInUserId = _appService.GetAuthenticatedUser()?.Id;
            long[] loggedInUserRoleIds = await GetLoggedInUserRoleIds();
            bool isInventoryManager = loggedInUserRoleIds.Contains(RoleConstants.InventoryManager);

            Expression<Func<Requisition, bool>> predicate = x => (x.InitiatorId == loggedInUserId
            || (x.CurrentApproverId == loggedInUserId && x.CurrentApproverId != null)
            || loggedInUserRoleIds.Contains(x.CurrentRoleApproverId.Value) && x.CurrentRoleApproverId != null)
            && !x.IsDeleted;

            var result = await _requisitionRepository.ListAsync(predicate, RequisitionListViewModel.Select(loggedInUserId, loggedInUserRoleIds, isInventoryManager), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        private async Task<long[]> GetLoggedInUserRoleIds()
        {
            long? loggedInUserId = _appService.GetAuthenticatedUser()?.Id;
            return await GetUserRoleIds(loggedInUserId);
        }

        private async Task<long[]> GetUserRoleIds(long? userId)
        {
            var userRoles = await _unitOfWork.GetRepository<UserRole>()
                .AsReadOnly()
                .Where(x => x.UserId == userId && !x.IsDeleted)
                .Select(x => x.RoleId)
                .ToArrayAsync();
            return userRoles;
        }

        private async Task<IdNameViewModel> GetConsumable(long assetId)
        {
            // Id contains Asset's Available value, Name contains Asset's name
            string sql = $@"with cte 
                        as (select c.ItemCodeId,
                        sum(c.Available) Available
                        from [asset].[Consumable] c
                        where c.IsDeleted = 0 and c.ItemCodeId = {assetId}
                        group by c.ItemCodeId
                        )
                        select top 1 cte.Available Id, concat(i.Code, ' - ', i.Name) Name from cte
                        left join [asset].[ItemCode] i on i.Id = cte.ItemCodeId";
            var asset = await _dbConnection.QueryFirstOrDefaultAsync<IdNameViewModel>(sql);
            return new IdNameViewModel
            {
                Id = asset == null ? 0 :
                asset.Id,
                Name = asset.Name ?? ""
            };
        }

    }
}
