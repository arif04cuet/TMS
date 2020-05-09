using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Module.Core.Data.Criteria;
using Module.Core.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
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

        public ConsumableService(
            IUnitOfWork unitOfWork,
            ICheckoutHistoryService checkoutHistoryService)
        {
            _unitOfWork = unitOfWork;
            _checkoutHistoryService = checkoutHistoryService;
            _consumableRepository = _unitOfWork.GetRepository<Consumable>();
            _consumableUserRepository = _unitOfWork.GetRepository<ConsumableUser>();
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public async Task<long> CreateAsync(ConsumableCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newEntity = request.ToMap();
            newEntity.Available = request.Quantity;

            await _consumableRepository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return newEntity.Id;
        }

        public async Task<bool> UpdateAsync(ConsumableUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _consumableRepository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Consumable not found");

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
            var entity = await _consumableRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Consumable not found");

            var checkout = await _consumableUserRepository.MatchAsync(new ConsumableCountByIdCriteria(entity.Id));

            if (checkout > 0)
                throw new NotFoundException("Can not be deleted. This consumable is assigned to user.");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
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
                    PurchaseDate = x.PurchaseDate,
                    PurchaseCost = x.PurchaseCost,
                    Note = x.Note,
                    Category = new AssetCategoryViewModel
                    {
                        Id = x.Category.Id,
                        Name = x.Category.Name,
                        IsSendEmailToUser = x.Category.IsSendEmail,
                        IsRequireUserConfirmation = x.Category.IsRequireUserConfirmation
                    },
                    Manufacturer = x.ManufacturerId != null ? new IdNameViewModel { Id = x.Manufacturer.Id, Name = x.Manufacturer.Name} : null,
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

        public async Task<PagedCollection<ConsumableViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _consumableRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new ConsumableViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    OrderNumber = x.OrderNumber,
                    PurchaseDate = x.PurchaseDate,
                    PurchaseCost = x.PurchaseCost,
                    Note = x.Note,
                    Category = new AssetCategoryViewModel
                    {
                        Id = x.Category.Id,
                        Name = x.Category.Name,
                        IsSendEmailToUser = x.Category.IsSendEmail,
                        IsRequireUserConfirmation = x.Category.IsRequireUserConfirmation
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

        public async Task<PagedCollection<ConsumableCheckoutListViewModel>> ListCheckoutAsync(long consumableId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var query = _consumableUserRepository
                .AsReadOnly()
                .Where(x => x.ConsumableId == consumableId && !x.IsDeleted)
                .ApplySearch(searchOptions);

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
                    }
                })
                .ToListAsync(cancellationToken);

            var total = await query.Select(x => x.Id).CountAsync(cancellationToken);

            var result = new PagedCollection<ConsumableCheckoutListViewModel>(items, total, pagingOptions);
            return result;

        }

        public async Task<bool> CheckoutAsync(ConsumableCheckoutRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _consumableRepository
                .FirstOrDefaultAsync(x => x.Id == request.ConsumableId && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Consumable not found");

            if (entity.Available <= 0)
                throw new NotFoundException("No available consumable to checkout");

            var userExist = await _userRepository.MatchAsync(new ExistUserByIdCriteria(request.UserId));

            if (!userExist)
                throw new NotFoundException("User not found");

            var checkout = new ConsumableUser
            {
                ConsumableId = request.ConsumableId,
                IssuedToUserId = request.UserId
            };

            await _consumableUserRepository.AddAsync(checkout);
            entity.Available = entity.Available - 1;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _checkoutHistoryService.CreateAsync(new CheckoutHistoryCreateRequest
            {
                Action = AssetAction.Checkout,
                ItemId = entity.Id,
                ItemType = AssetType.Consumable,
                Note = request.Note,
                TargetId = request.UserId,
                TargetType = AssetType.User
            });

            return result > 0;
        }

        public async Task<bool> CheckinAsync(ConsumableCheckinRequest request, CancellationToken cancellationToken = default)
        {
            var checkin = await _consumableUserRepository
                .AsQueryable()
                .Include(x => x.Consumable)
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (checkin == null)
                throw new NotFoundException("Checkout not found");

            _consumableUserRepository.Remove(checkin);
            checkin.Consumable.Available = checkin.Consumable.Available + 1;

            var result = await _unitOfWork.SaveChangesAsync();

            await _checkoutHistoryService.CreateAsync(new CheckoutHistoryCreateRequest
            {
                Action = AssetAction.Checkin,
                ItemId = checkin.Consumable.Id,
                ItemType = AssetType.Consumable,
                Note = request.Note,
                TargetId = checkin.IssuedToUserId,
                TargetType = AssetType.User
            });

            return result > 0;
        }
    }
}
