using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class ComponentService : IComponentService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Component> _componentRepository;
        private readonly IRepository<ComponentAsset> _componentAssetRepository;
        private readonly IRepository<Entities.Asset> _assetRepository;
        private readonly ICheckoutHistoryService _checkoutHistoryService;

        public ComponentService(
            IUnitOfWork unitOfWork,
            ICheckoutHistoryService checkoutHistoryService)
        {
            _unitOfWork = unitOfWork;
            _checkoutHistoryService = checkoutHistoryService;
            _componentRepository = _unitOfWork.GetRepository<Component>();
            _componentAssetRepository = _unitOfWork.GetRepository<ComponentAsset>();
            _assetRepository = _unitOfWork.GetRepository<Entities.Asset>();
        }

        public async Task<long> CreateAsync(ComponentCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newEntity = request.ToMap();
            await _componentRepository.AddAsync(newEntity, cancellationToken);
            newEntity.Available = request.Quantity;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return newEntity.Id;
        }

        public async Task<bool> UpdateAsync(ComponentUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _componentRepository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Component not found");

            var totalCheckout = await _componentAssetRepository
                .Where(x => x.ComponentId == entity.Id && !x.IsDeleted)
                .Select(x => x.Quantity)
                .SumAsync();

            if (request.Quantity < totalCheckout)
                throw new ValidationException("Assigned components can not be deleted.");

            entity = request.ToMap(entity);

            var available = entity.Quantity - totalCheckout;
            entity.Available = available;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _componentRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Component not found");

            var checkout = await _componentAssetRepository.MatchAsync(new ComponentCountByIdCriteria(entity.Id));

            if (checkout > 0)
                throw new NotFoundException("Can not be deleted. This component is assigned to user.");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<ComponentViewModel> Get(long id, CancellationToken cancellationToken = default)
        {

            var result = await _componentRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new ComponentViewModel
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
                throw new NotFoundException("Component not found");

            return result;
        }

        public async Task<PagedCollection<ComponentViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _componentRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new ComponentViewModel
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

            var result = new PagedCollection<ComponentViewModel>(items, total, pagingOptions);
            return result;
        }

        public async Task<PagedCollection<ComponentCheckoutListViewModel>> ListCheckoutAsync(long componentId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var query = _componentAssetRepository
                .AsReadOnly()
                .Where(x => x.ComponentId == componentId && !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new ComponentCheckoutListViewModel
                {
                    Id = x.Id,
                    ComponentId = x.ComponentId,
                    Asset = new IdNameViewModel
                    {
                        Id = x.IssuedToAsset.Id,
                        Name = x.IssuedToAsset.Name
                    },
                    Quantity = x.Quantity
                })
                .ToListAsync(cancellationToken);

            var total = await query.Select(x => x.Id).CountAsync(cancellationToken);

            var result = new PagedCollection<ComponentCheckoutListViewModel>(items, total, pagingOptions);
            return result;

        }

        public async Task<ComponentCheckoutListViewModel> GetCheckoutAsync(long checkoutId, CancellationToken cancellationToken = default)
        {
            var checkout = await _componentAssetRepository
                .Where(x => x.Id == checkoutId && !x.IsDeleted, true)
                .Select(x => new ComponentCheckoutListViewModel
                {
                    Id = x.Id,
                    ComponentId = x.ComponentId,
                    Asset = new IdNameViewModel
                    {
                        Id = x.IssuedToAsset.Id,
                        Name = x.IssuedToAsset.Name
                    },
                    Quantity = x.Quantity
                })
                .FirstOrDefaultAsync(cancellationToken);
            return checkout;
        }

        public async Task<bool> CheckoutAsync(ComponentCheckoutRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _componentRepository
                .FirstOrDefaultAsync(x => x.Id == request.ComponentId && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Component not found");

            if (entity.Available <= 0)
                throw new NotFoundException("No available component to checkout");

            if (entity.Available < request.Quantity)
                throw new NotFoundException("Qantity exceeds.");

            var assetExist = await _assetRepository.MatchAsync(new ExistAssetByIdCriteria(request.AssetId));

            if (!assetExist)
                throw new NotFoundException("Asset not found");

            var checkout = new ComponentAsset
            {
                ComponentId = request.ComponentId,
                IssuedToAssetId = request.AssetId,
                Quantity = request.Quantity
            };

            await _componentAssetRepository.AddAsync(checkout);
            entity.Available = entity.Available - request.Quantity;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _checkoutHistoryService.CreateAsync(new CheckoutHistoryCreateRequest
            {
                Action = AssetAction.Checkout,
                ItemId = entity.Id,
                ItemType = AssetType.Component,
                Note = request.Note,
                TargetId = request.AssetId,
                TargetType = AssetType.Asset
            });

            return result > 0;
        }

        public async Task<bool> CheckinAsync(ComponentCheckinRequest request, CancellationToken cancellationToken = default)
        {
            var checkin = await _componentAssetRepository
                .AsQueryable()
                .Include(x => x.Component)
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (checkin == null)
                throw new NotFoundException("Checkout not found");

            if (checkin.Quantity < request.Quantity)
                throw new NotFoundException("Qantity exceeds.");

            if (checkin.Quantity == request.Quantity)
            {
                _componentAssetRepository.Remove(checkin);
            }
            else if (checkin.Quantity > request.Quantity)
            {
                checkin.Quantity = checkin.Quantity - request.Quantity;
            }

            checkin.Component.Available = checkin.Component.Available + request.Quantity;

            var result = await _unitOfWork.SaveChangesAsync();

            await _checkoutHistoryService.CreateAsync(new CheckoutHistoryCreateRequest
            {
                Action = AssetAction.Checkin,
                ItemId = checkin.Component.Id,
                ItemType = AssetType.Component,
                Note = request.Note,
                TargetId = checkin.IssuedToAssetId,
                TargetType = AssetType.Asset
            });

            return result > 0;
        }
    }
}
