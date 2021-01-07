using Dapper;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Module.Core.Data.Criteria;
using Module.Core.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class ConsumableService : IConsumableService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Consumable> _consumableRepository;
        private readonly IRepository<ConsumableUser> _consumableUserRepository;
        private readonly IRepository<User> _userRepository;
        private readonly ICheckoutHistoryService _checkoutHistoryService;
        private readonly IAssetEmailService _assetEmailService;
        private readonly IDbConnection _dbConnection;

        private static object lockObject = new object();

        public ConsumableService(
            IUnitOfWork unitOfWork,
            ICheckoutHistoryService checkoutHistoryService,
            IAssetEmailService assetEmailService)
        {
            _unitOfWork = unitOfWork;
            _checkoutHistoryService = checkoutHistoryService;
            _consumableRepository = _unitOfWork.GetRepository<Consumable>();
            _consumableUserRepository = _unitOfWork.GetRepository<ConsumableUser>();
            _userRepository = _unitOfWork.GetRepository<User>();
            _assetEmailService = assetEmailService;
            _dbConnection = _unitOfWork.GetConnection();
        }

        public async Task<long> CreateAsync(ConsumableCreateRequest request, CancellationToken cancellationToken = default)
        {
            var itemCode = await _unitOfWork.GetRepository<ItemCode>()
                .FirstOrDefaultAsync(x => x.Id == request.ItemCode && !x.IsDeleted);

            if (itemCode == null)
                throw new NotFoundException("Item code not found.");

            var newEntity = request.ToMap();
            newEntity.Available = request.Quantity;

            // calculate total
            itemCode.TotalQuantity = GetTotalQuantity(itemCode.Id) + request.Quantity;

            // calculate available
            itemCode.Available = GetTotalAvailables(itemCode.Id) + request.Quantity;

            await _consumableRepository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return newEntity.Id;
        }

        public async Task<bool> UpdateAsync(ConsumableUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _consumableRepository
                .AsQueryable()
                .Include(x => x.ItemCode)
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Consumable not found");

            if (entity.ItemCodeId != request.ItemCode)
                throw new ValidationException("Item code can not be updated.");

            var totalCheckout = await _consumableUserRepository.MatchAsync(new ConsumableCountByIdCriteria(entity.Id));

            if (request.Quantity < totalCheckout)
                throw new ValidationException("Assigned consumables can not be deleted.");

            entity = request.ToMap(entity);

            var available = entity.Quantity - totalCheckout;
            entity.Available = available;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _consumableRepository
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException("Consumable not found");

            var checkout = await _consumableUserRepository.MatchAsync(new ConsumableCountByIdCriteria(entity.Id));

            if (checkout > 0)
                throw new NotFoundException("Can not be deleted. This consumable is assigned to user.");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var itemCode = await _unitOfWork.GetRepository<ItemCode>()
                .FirstOrDefaultAsync(x => x.Id == entity.ItemCodeId && !x.IsDeleted);

            if (itemCode != null)
            {
                // calculate total
                itemCode.TotalQuantity = GetTotalQuantity(itemCode.Id);

                // calculate available
                itemCode.Available = GetTotalAvailables(itemCode.Id);
                result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return result > 0;
        }

        public async Task<ConsumableViewModel> Get(long id, CancellationToken cancellationToken = default)
        {

            var result = await _consumableRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new ConsumableViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    OrderNumber = x.OrderNumber,
                    InvoiceNumber = x.InvoiceNumber,
                    PurchaseDate = x.PurchaseDate,
                    PurchaseCost = x.PurchaseCost,
                    Note = x.Note,
                    ItemCode = new AssetItemCodeViewModel { Id = x.ItemCode.Id, Code = x.ItemCode.Code, Name = x.ItemCode.Name },
                    Category = new AssetCategoryViewModel
                    {
                        Id = x.ItemCode.Category.Id,
                        Name = x.ItemCode.Category.Name,
                        IsSendEmailToUser = x.ItemCode.Category.IsSendEmail,
                        IsRequireUserConfirmation = x.ItemCode.Category.IsRequireUserConfirmation
                    },
                    Manufacturer = x.ManufacturerId != null ? new IdNameViewModel { Id = x.Manufacturer.Id, Name = x.Manufacturer.Name } : null,
                    Supplier = x.SupplierId != null ? new IdNameViewModel { Id = x.Supplier.Id, Name = x.Supplier.Name } : null,
                    Location = x.LocationId != null ? new IdNameViewModel { Id = x.Location.Id, Name = x.Location.OfficeName } : null,
                    MinQuantity = x.MinQuantity,
                    ModelNo = x.ModelNo,
                    Quantity = x.Quantity,
                    Available = x.Available
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Consumable not found");

            return result;
        }

        public async Task<PagedCollection<ConsumableViewModel>> ListAsync(long? itemCodeId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _consumableRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            if (itemCodeId.HasValue)
            {
                itemsQuery = itemsQuery.Where(x => x.ItemCodeId == itemCodeId.Value);
            }

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new ConsumableViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    OrderNumber = x.OrderNumber,
                    InvoiceNumber = x.InvoiceNumber,
                    PurchaseDate = x.PurchaseDate,
                    PurchaseCost = x.PurchaseCost,
                    Note = x.Note,
                    ItemCode = new AssetItemCodeViewModel { Id = x.ItemCode.Id, Code = x.ItemCode.Code, Name = x.ItemCode.Name },
                    Category = new AssetCategoryViewModel
                    {
                        Id = x.ItemCode.Category.Id,
                        Name = x.ItemCode.Category.Name,
                        IsSendEmailToUser = x.ItemCode.Category.IsSendEmail,
                        IsRequireUserConfirmation = x.ItemCode.Category.IsRequireUserConfirmation
                    },
                    Manufacturer = x.ManufacturerId != null ? new IdNameViewModel { Id = x.Manufacturer.Id, Name = x.Manufacturer.Name } : null,
                    Supplier = x.SupplierId != null ? new IdNameViewModel { Id = x.Supplier.Id, Name = x.Supplier.Name } : null,
                    Location = x.LocationId != null ? new IdNameViewModel { Id = x.Location.Id, Name = x.Location.OfficeName } : null,
                    MinQuantity = x.MinQuantity,
                    ModelNo = x.ModelNo,
                    Quantity = x.Quantity,
                    Available = x.Available
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<ConsumableViewModel>(items, total, pagingOptions);
            return result;
        }

        public async Task<PagedCollection<ConsumableListGroupByItemCodeViewModel>> ListGroupByItemCodeAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var sql = @"with cte
                        as (select c.ItemCodeId,
                        sum(c.Available) Available, sum(c.Quantity) Quantity
                        from [asset].[Consumable] c
                        where c.IsDeleted = 0
                        group by c.ItemCodeId
                        )
                        select cte.ItemCodeId Id, cte.Available, cte.Quantity,
                        concat(i.Code, ' - ', i.Name) Item,
                        c.Name Category, c.Id CategoryId, i.MinQuantity,
                        i.TotalQuantity ItemQuantity, i.Available as ItemAvailable from cte
                        left join [asset].[ItemCode] i on i.Id = cte.ItemCodeId
                        left join [asset].[Category] c on c.Id = i.CategoryId";

            string where = searchOptions.ToSqlSyntax((prop, index) => "cte.");
            if (!string.IsNullOrEmpty(where))
            {
                sql += $" where {where} ";
            }

            var itemSql = sql + $" order by i.Code ";
            itemSql += pagingOptions.BuildSql();

            var totalSql = @"with cte
                            as (select c.ItemCodeId
                            from [asset].[Consumable] c
                            group by c.ItemCodeId
                            )
                            select count(cte.ItemCodeId) from cte";

            string totalWhere = searchOptions.ToSqlSyntax((prop, index) => "cte.");
            if (!string.IsNullOrEmpty(totalWhere))
            {
                totalSql += $" where {where} ";
            }

            var items = await _dbConnection.QueryAsync<ConsumableListGroupByItemCodeViewModel>(itemSql);
            var total = await _dbConnection.ExecuteScalarAsync<int>(totalSql);

            var result = new PagedCollection<ConsumableListGroupByItemCodeViewModel>(items, total, pagingOptions);
            return result;
        }

        public async Task<PagedCollection<ConsumableCheckoutListViewModel>> ListCheckoutAsync(long consumableId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await ListCheckoutInternalAsync(x => x.ConsumableId == consumableId, pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<ConsumableCheckoutViewModel> GetCheckoutAsync(long checkoutId, CancellationToken cancellationToken = default)
        {
            var checkout = await _consumableUserRepository
                .Where(x => x.Id == checkoutId && !x.IsDeleted, true)
                .Select(x => new ConsumableCheckoutViewModel
                {
                    Id = x.Id,
                    ConsumableId = x.ConsumableId,
                    User = new IdNameViewModel
                    {
                        Id = x.IssuedToUser.Id,
                        Name = x.IssuedToUser.FullName
                    },
                    IssueDate = x.IssueDate,
                    Quantity = x.Quantity,
                    Item = new AssetItemCodeViewModel
                    {
                        Id = x.Consumable.ItemCode.Id,
                        Name = x.Consumable.ItemCode.Name,
                        Code = x.Consumable.ItemCode.Code
                    },
                    Category = new AssetCategoryViewModel
                    {
                        Id = x.Consumable.ItemCode.Category.Id,
                        Name = x.Consumable.ItemCode.Category.Name
                    }
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (checkout == null)
                throw new ValidationException("Checkout not found");

            return checkout;
        }

        public async Task<PagedCollection<ConsumableCheckoutListViewModel>> ListCheckoutByItemCodeAsync(long itemCodeId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await ListCheckoutInternalAsync(x => x.Consumable.ItemCodeId == itemCodeId, pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<bool> CheckoutAsync(ConsumableCheckoutRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _consumableRepository
                .AsQueryable()
                .Include(x => x.ItemCode)
                .FirstOrDefaultAsync(x => x.Id == request.ConsumableId && !x.IsDeleted);

            var result = await CheckoutInternalAsync(entity, request.UserId, request.Quantity, request.Note, true, cancellationToken);

            return result;
        }

        public async Task<bool> CheckoutByItemCodeAsync(ConsumableCheckoutByItemCodeRequest request, CancellationToken cancellationToken = default)
        {
            int quantity = 0;
            List<Consumable> consumables = new List<Consumable>();
            int iteration = 0;
            int skip = 0;
            int take = 1;

            while (quantity <= request.Quantity)
            {
                var entities = await _consumableRepository
                    .Where(x => x.ItemCodeId == request.ItemCodeId && x.Available > 0 && !x.IsDeleted)
                    .Include(x => x.ItemCode)
                    .OrderByDescending(x => x.Available)
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync(cancellationToken);

                if (entities == null || entities.Count <= 0)
                    break;

                var entity = entities[0];
                quantity += entity.Available.Value;
                consumables.Add(entity);

                ++skip;
                ++iteration;
            }

            if (quantity < request.Quantity)
                throw new ValidationException("Insufficient quantity.");

            int available = request.Quantity;
            var result = false;
            foreach (var item in consumables)
            {
                if (available > 0)
                {
                    int qty = 0;
                    if (item.Available.Value < available)
                    {
                        qty = item.Available.Value;
                    }
                    else if (item.Available.Value >= available)
                    {
                        qty = available;
                    }
                    available = available - qty;
                    result &= await CheckoutInternalAsync(item, request.UserId, qty, request.Note, false, cancellationToken);
                }
            }

            return result;
        }

        public async Task<bool> CheckinAsync(ConsumableCheckinRequest request, CancellationToken cancellationToken = default)
        {
            var checkin = await _consumableUserRepository
                .AsQueryable()
                .Include(x => x.Consumable).ThenInclude(x => x.ItemCode)
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (checkin == null)
                throw new NotFoundException("Checkout not found");

            if (checkin.Consumable.ItemCode == null)
                throw new NotFoundException("Item code not found");

            if (request.Quantity > checkin.Quantity)
                throw new ValidationException("Return quantity can not be greater than checkout qantity");

            int checkingQty = checkin.Quantity;
            lock (lockObject)
            {
                checkin.Quantity = checkin.Quantity - request.Quantity;
                checkin.Consumable.Available = checkin.Consumable.Available + request.Quantity;
                checkin.Consumable.ItemCode.Available = checkin.Consumable.ItemCode.Available + request.Quantity;
            }

            var result = await _unitOfWork.SaveChangesAsync();

            if (request.Quantity == checkingQty)
                _consumableUserRepository.Remove(checkin);

            result += await _unitOfWork.SaveChangesAsync();

            await _checkoutHistoryService.CreateAsync(new CheckoutHistoryCreateRequest
            {
                Action = AssetAction.Checkin,
                ItemId = checkin.Consumable.Id,
                ItemType = AssetType.Consumable,
                Note = request.Note,
                TargetId = checkin.IssuedToUserId,
                TargetType = AssetType.User,
                Quantity = request.Quantity
            });

            return result > 0;
        }

        private async Task<bool> CheckoutInternalAsync(Consumable entity, long userId, int quantity, string note, bool sendEULA = true, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                throw new NotFoundException("Consumable not found");

            int? totalAvailables = GetTotalAvailables(entity.ItemCodeId);
            if (entity.Available <= 0 || entity.ItemCode.Available <= 0 || totalAvailables <= 0)
                throw new NotFoundException("No available consumable to checkout");

            var userExist = await _userRepository.MatchAsync(new ExistUserByIdCriteria(userId));

            if (!userExist)
                throw new NotFoundException("User not found");

            var checkout = new ConsumableUser
            {
                ConsumableId = entity.Id,
                IssuedToUserId = userId,
                Quantity = quantity,
                IssueDate = DateTime.UtcNow
            };

            await _consumableUserRepository.AddAsync(checkout);
            entity.Available = entity.Available - quantity;
            entity.ItemCode.Available = totalAvailables - quantity;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _checkoutHistoryService.CreateAsync(new CheckoutHistoryCreateRequest
            {
                Action = AssetAction.Checkout,
                ItemId = entity.Id,
                ItemType = AssetType.Consumable,
                Note = note,
                TargetId = userId,
                TargetType = AssetType.User,
                Quantity = quantity
            });

            if (sendEULA)
            {
                await _assetEmailService.SendEULAEmailAsync(userId, entity.ItemCode.CategoryId);
            }

            return result > 0;
        }

        private async Task<PagedCollection<ConsumableCheckoutListViewModel>> ListCheckoutInternalAsync(Expression<Func<ConsumableUser, bool>> predicate, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var query = _consumableUserRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new ConsumableCheckoutListViewModel
                {
                    Id = x.Id,
                    ConsumableId = x.ConsumableId,
                    User = new IdNameViewModel
                    {
                        Id = x.IssuedToUser.Id,
                        Name = x.IssuedToUser.FullName
                    },
                    IssueDate = x.IssueDate,
                    Quantity = x.Quantity
                })
                .ToListAsync(cancellationToken);

            var total = await query.Select(x => x.Id).CountAsync(cancellationToken);

            var result = new PagedCollection<ConsumableCheckoutListViewModel>(items, total, pagingOptions);
            return result;
        }

        private int? GetTotalAvailables(long itemCodeId)
        {
            var consumableAvailables = _consumableRepository
                .Where(x => x.ItemCodeId == itemCodeId && !x.IsDeleted)
                .Select(x => x.Available)
                .Sum();
            return consumableAvailables;
        }

        private int GetTotalQuantity(long itemCodeId)
        {
            var consumableTotal = _consumableRepository
                .Where(x => x.ItemCodeId == itemCodeId && !x.IsDeleted)
                .Select(x => x.Quantity)
                .Sum();
            return consumableTotal;
        }
    }
}
