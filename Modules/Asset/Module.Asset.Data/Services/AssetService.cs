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
    public class AssetService : IAssetService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Entities.Asset> _assetRepository;
        private readonly IRepository<AssetCheckout> _assetCheckoutRepository;
        private readonly ICheckoutHistoryService _checkoutHistoryService;
        private readonly IBarcodeService _barcodeService;
        private readonly IRepository<ComponentAsset> _componentAssetRepository;
        private readonly IAssetEmailService _assetEmailService;

        public AssetService(
            IUnitOfWork unitOfWork,
            ICheckoutHistoryService checkoutHistoryService,
            IBarcodeService barcodeService,
            IAssetEmailService assetEmailService)
        {
            _barcodeService = barcodeService;
            _checkoutHistoryService = checkoutHistoryService;
            _unitOfWork = unitOfWork;
            _assetRepository = _unitOfWork.GetRepository<Entities.Asset>();
            _assetCheckoutRepository = _unitOfWork.GetRepository<AssetCheckout>();
            _componentAssetRepository = _unitOfWork.GetRepository<ComponentAsset>();
            _assetEmailService = assetEmailService;
        }

        public async Task<long> CreateAsync(AssetCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newEntity = request.ToMap();
            newEntity.Barcode = _barcodeService.Generate();
            await _assetRepository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return newEntity.Id;
        }

        public async Task<bool> UpdateAsync(AssetUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _assetRepository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Asset not found");

            entity = request.ToMap(entity);

            if (string.IsNullOrEmpty(entity.Barcode))
            {
                entity.Barcode = _barcodeService.Generate();
            }

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _assetRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Asset not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<AssetViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var query = _assetRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted);

            var assetCheckouts = _assetCheckoutRepository.AsQueryable();

            var result = await (from x in query
                                join assetCheckout in assetCheckouts on x.Id equals assetCheckout.AssetId into checkouts
                                from checkout in checkouts.DefaultIfEmpty()
                                select new AssetViewModel
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    PurchaseDate = x.PurchaseDate,
                                    PurchaseCost = x.PurchaseCost,
                                    Note = x.Note,
                                    Supplier = x.SupplierId != null ? new IdNameViewModel { Id = x.Supplier.Id, Name = x.Supplier.Name } : null,
                                    Location = x.LocationId != null ? new IdNameViewModel { Id = x.Location.Id, Name = x.Location.OfficeName } : null,
                                    AssetModel = new IdNameViewModel { Id = x.AssetModel.Id, Name = x.AssetModel.Name },
                                    IsRequestable = x.IsRequestable,
                                    ItemNo = x.ItemNo,
                                    OrderNo = x.OrderNo,
                                    Status = new IdNameViewModel { Id = x.Status.Id, Name = x.Status.Name },
                                    Warranty = x.Warranty,
                                    Barcode = x.Barcode,
                                    Category = new AssetCategoryViewModel { Id = x.AssetModel.Category.Id, Name = x.AssetModel.Category.Name, IsRequireUserConfirmation = x.AssetModel.Category.IsRequireUserConfirmation, IsSendEmailToUser = x.AssetModel.Category.IsSendEmail },

                                    CheckoutToUser = checkout != null && checkout.ChekoutToUserId != null ? new IdNameViewModel { Id = checkout.ChekoutToUser.Id, Name = checkout.ChekoutToUser.FullName } : null,

                                    CheckoutToLocation = checkout != null && checkout.ChekoutToLocationId != null ? new IdNameViewModel { Id = checkout.ChekoutToLocation.Id, Name = checkout.ChekoutToLocation.OfficeName } : null,
                                    CheckoutId = checkout.Id
                                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Asset not found");

            return result;
        }

        public async Task<PagedCollection<AssetViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var assets = _assetRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions)
                .ApplyPagination(pagingOptions);

            var assetCheckouts = _assetCheckoutRepository.AsQueryable();

            var results = from asset in assets
                          join assetCheckout in assetCheckouts on asset.Id equals assetCheckout.AssetId into checkouts
                          from checkout in checkouts.DefaultIfEmpty()
                          select new AssetViewModel
                          {
                              Id = asset.Id,
                              Barcode = asset.Barcode,
                              AssetModel = new IdNameViewModel { Id = asset.AssetModelId, Name = asset.AssetModel.Name },
                              ItemNo = asset.ItemNo,
                              Name = asset.Name,
                              IsRequestable = asset.IsRequestable,
                              Location = asset.LocationId != null ? new IdNameViewModel { Id = asset.Location.Id, Name = asset.Location.OfficeName } : null,
                              Note = asset.Note,
                              OrderNo = asset.OrderNo,
                              PurchaseCost = asset.PurchaseCost,
                              PurchaseDate = asset.PurchaseDate,
                              Status = new IdNameViewModel { Id = asset.Status.Id, Name = asset.Status.Name },
                              Supplier = asset.SupplierId != null ? new IdNameViewModel { Id = asset.Supplier.Id, Name = asset.Supplier.Name } : null,
                              Warranty = asset.Warranty,
                              CheckoutToUser = checkout != null && checkout.ChekoutToUserId != null ? new IdNameViewModel { Id = checkout.ChekoutToUser.Id, Name = checkout.ChekoutToUser.FullName } : null,
                              CheckoutToLocation = checkout != null && checkout.ChekoutToLocationId != null ? new IdNameViewModel { Id = checkout.ChekoutToLocation.Id, Name = checkout.ChekoutToLocation.OfficeName } : null,
                              Category = new AssetCategoryViewModel { Id = asset.AssetModel.Category.Id, Name = asset.AssetModel.Category.Name, IsSendEmailToUser = asset.AssetModel.Category.IsSendEmail, IsRequireUserConfirmation = asset.AssetModel.Category.IsRequireUserConfirmation },
                              CheckoutId = checkout.Id
                          };

            var total = await assets.Select(x => x.Id).CountAsync(cancellationToken);
            var items = await results.ToListAsync(cancellationToken);

            var result = new PagedCollection<AssetViewModel>(items, total, pagingOptions);
            return result;
        }

        public async Task<bool> CheckoutAsync(AssetCheckoutRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _assetRepository
                .FirstOrDefaultAsync(x => x.Id == request.AssetId && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Asset not found");

            AssetCheckout oldCheckout = oldCheckout = await _assetCheckoutRepository.FirstOrDefaultAsync(x => x.AssetId == request.AssetId && !x.IsDeleted, true);

            if (oldCheckout != null)
                throw new ValidationException("Asset is already assigned.");

            var checkout = new AssetCheckout
            {
                AssetId = request.AssetId,
                CheckoutDate = request.CheckoutDate,
                ChekoutToLocationId = request.ChekoutToLocationId,
                ChekoutToUserId = request.ChekoutToUserId,
                ExpectedChekinDate = request.ExpectedChekinDate
            };

            await _assetCheckoutRepository.AddAsync(checkout);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _checkoutHistoryService.CreateAsync(new CheckoutHistoryCreateRequest
            {
                Action = AssetAction.Checkout,
                ItemId = entity.Id,
                ItemType = AssetType.Asset,
                Note = request.Note,
                TargetId = request.ChekoutToUserId.HasValue ? request.ChekoutToUserId : request.ChekoutToLocationId,
                TargetType = request.ChekoutToUserId.HasValue ? AssetType.User : AssetType.Location
            });

            if(request.ChekoutToUserId.HasValue)
            {
                await _assetEmailService.SendEULAEmailAsync(request.ChekoutToUserId.Value, entity.AssetModel.CategoryId);
            }

            return result > 0;
        }

        public async Task<bool> CheckinAsync(AssetCheckinRequest request, CancellationToken cancellationToken = default)
        {
            var checkin = await _assetCheckoutRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (checkin == null)
                throw new NotFoundException("Checkout not found");

            var asset = await _assetRepository.
                FirstOrDefaultAsync(x => x.Id == checkin.AssetId && !x.IsDeleted);

            if (asset == null)
                throw new NotFoundException("Asset not found");

            _assetCheckoutRepository.Remove(checkin);
            
            if(request.Status.HasValue)
            {
                asset.StatusId = request.Status.Value;
            }

            await _checkoutHistoryService.CreateAsync(new CheckoutHistoryCreateRequest
            {
                Action = AssetAction.Checkin,
                ItemId = checkin.AssetId,
                ItemType = AssetType.Asset,
                Note = request.Note,
                TargetId = checkin.ChekoutToUserId.HasValue ? checkin.ChekoutToUserId : checkin.ChekoutToLocationId,
                TargetType = checkin.ChekoutToUserId.HasValue ? AssetType.User : AssetType.Location
            });

            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }

        public async Task<PagedCollection<AssetComponentListViewModel>> ListComponentsAsync(long assetId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var query = _componentAssetRepository
                .AsReadOnly()
                .Where(x => x.IssuedToAssetId == assetId && !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new AssetComponentListViewModel
                {
                    Id = x.Id,
                    Component = new IdNameViewModel { Id = x.Component.Id, Name = x.Component.Name },
                    Quantity = x.Quantity
                })
                .ToListAsync(cancellationToken);

            var total = await query.Select(x => x.Id).CountAsync(cancellationToken);

            var result = new PagedCollection<AssetComponentListViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
