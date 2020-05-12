using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Services;
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
    public class AccessoryService : IAccessoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Accessory> _accessoryRepository;
        private readonly IRepository<AccessoryUser> _accessoryUserRepository;
        private readonly IRepository<User> _userRepository;
        private readonly ICheckoutHistoryService _checkoutHistoryService;
        private readonly IAssetEmailService _assetEmailService;

        public AccessoryService(
            IUnitOfWork unitOfWork,
            ICheckoutHistoryService checkoutHistoryService,
            IAssetEmailService assetEmailService)
        {
            _unitOfWork = unitOfWork;
            _accessoryRepository = _unitOfWork.GetRepository<Accessory>();
            _accessoryUserRepository = _unitOfWork.GetRepository<AccessoryUser>();
            _userRepository = _unitOfWork.GetRepository<User>();
            _checkoutHistoryService = checkoutHistoryService;
            _assetEmailService = assetEmailService;
        }

        public async Task<long> CreateAsync(AccessoryCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newEntity = request.ToMap();
            newEntity.Available = request.Quantity;

            await _accessoryRepository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return newEntity.Id;
        }

        public async Task<bool> UpdateAsync(AccessoryUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _accessoryRepository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Accessory not found");

            var totalCheckout = await _accessoryUserRepository.MatchAsync(new AccessoryCountByIdCriteria(entity.Id));

            if (request.Quantity < totalCheckout)
                throw new ValidationException("Assigned accessories can not be deleted.");

            entity = request.ToMap(entity);

            var available = entity.Quantity - totalCheckout;
            entity.Available = available;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _accessoryRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Accessory not found");

            var checkout = await _accessoryUserRepository.MatchAsync(new AccessoryCountByIdCriteria(entity.Id));

            if (checkout > 0)
                throw new NotFoundException("Can not be deleted. This accessory is assigned to user.");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<AccessoryViewModel> Get(long id, CancellationToken cancellationToken = default)
        {

            var result = await _accessoryRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new AccessoryViewModel
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
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Accessory not found");

            return result;
        }

        public async Task<PagedCollection<AccessoryViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _accessoryRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new AccessoryViewModel
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

            var result = new PagedCollection<AccessoryViewModel>(items, total, pagingOptions);
            return result;
        }

        public async Task<PagedCollection<AccessoryCheckoutListViewModel>> ListCheckoutAsync(long accessoryId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var query = _accessoryUserRepository
                .AsReadOnly()
                .Where(x => x.AccessoryId == accessoryId && !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new AccessoryCheckoutListViewModel
                {
                    Id = x.Id,
                    AccessoryId = x.AccessoryId,
                    User = new IdNameViewModel
                    {
                        Id = x.IssuedToUser.Id,
                        Name = x.IssuedToUser.FullName
                    }
                })
                .ToListAsync(cancellationToken);

            var total = await query.Select(x => x.Id).CountAsync(cancellationToken);

            var result = new PagedCollection<AccessoryCheckoutListViewModel>(items, total, pagingOptions);
            return result;

        }

        public async Task<bool> CheckoutAsync(AccessoryCheckoutRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _accessoryRepository
                .FirstOrDefaultAsync(x => x.Id == request.AccessoryId && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Accessory not found");

            if (entity.Available <= 0)
                throw new NotFoundException("No available accessory to checkout");

            var userExist = await _userRepository.MatchAsync(new ExistUserByIdCriteria(request.UserId));

            if (!userExist)
                throw new NotFoundException("User not found");

            var checkout = new AccessoryUser
            {
                AccessoryId = request.AccessoryId,
                IssuedToUserId = request.UserId
            };

            await _accessoryUserRepository.AddAsync(checkout);
            entity.Available = entity.Available - 1;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _checkoutHistoryService.CreateAsync(new CheckoutHistoryCreateRequest
            {
                Action = AssetAction.Checkout,
                ItemId = entity.Id,
                ItemType = AssetType.Accessory,
                Note = request.Note,
                TargetId = request.UserId,
                TargetType = AssetType.User
            });

            await _assetEmailService.SendEULAEmailAsync(request.UserId, entity.CategoryId);

            return result > 0;
        }

        public async Task<bool> CheckinAsync(AccessoryCheckinRequest request, CancellationToken cancellationToken = default)
        {
            var checkin = await _accessoryUserRepository
                .AsQueryable()
                .Include(x => x.Accessory)
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (checkin == null)
                throw new NotFoundException("Checkout not found");

            _accessoryUserRepository.Remove(checkin);
            checkin.Accessory.Available = checkin.Accessory.Available + 1;

            var result = await _unitOfWork.SaveChangesAsync();

            await _checkoutHistoryService.CreateAsync(new CheckoutHistoryCreateRequest
            {
                Action = AssetAction.Checkin,
                ItemId = checkin.Accessory.Id,
                ItemType = AssetType.Accessory,
                Note = request.Note,
                TargetId = checkin.IssuedToUserId,
                TargetType = AssetType.User
            });

            return result > 0;
        }

    }
}
