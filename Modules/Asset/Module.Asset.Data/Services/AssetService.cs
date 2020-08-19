using Dapper;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Module.Core.Data;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Collections.Generic;
using System.Data;
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
        private readonly IRepository<LicenseSeat> _licenseSeatRepository;
        private readonly IRepository<Depreciation> _depreciationRepository;
        private readonly IAssetEmailService _assetEmailService;
        private readonly IMediaService _mediaService;
        private readonly IDbConnection _dbConnection;

        public AssetService(
            IUnitOfWork unitOfWork,
            IMediaService mediaService,
            ICheckoutHistoryService checkoutHistoryService,
            IBarcodeService barcodeService,
            IAssetEmailService assetEmailService)
        {
            _mediaService = mediaService;
            _barcodeService = barcodeService;
            _checkoutHistoryService = checkoutHistoryService;
            _unitOfWork = unitOfWork;
            _assetRepository = _unitOfWork.GetRepository<Entities.Asset>();
            _assetCheckoutRepository = _unitOfWork.GetRepository<AssetCheckout>();
            _componentAssetRepository = _unitOfWork.GetRepository<ComponentAsset>();
            _assetEmailService = assetEmailService;
            _licenseSeatRepository = _unitOfWork.GetRepository<LicenseSeat>();
            _depreciationRepository = _unitOfWork.GetRepository<Depreciation>();
            _dbConnection = _unitOfWork.GetConnection();
        }

        public async Task<long> CreateAsync(AssetCreateRequest request, CancellationToken cancellationToken = default)
        {
            var assets = request.ToMap(_barcodeService);
            await _assetRepository.AddRangeAsync(assets, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            foreach (var asset in assets)
            {
                var depreciation = await _depreciationRepository
                    .AsReadOnly()
                    .FirstOrDefaultAsync(x => x.Id == asset.DepreciationId && !x.IsDeleted);

                if (depreciation == null)
                    throw new NotFoundException("Depreciation not found.");


                var term = depreciation.Term * 12; // months
                var frequency = term / depreciation.Frequency;
                var depreciationRatePerFrequency = 100 / frequency; // %
                var depreciationValuePerFrequency = asset.PurchaseCost / frequency;

                var assetDepreciation = new AssetDepreciation
                {
                    AssetId = asset.Id,
                    Term = depreciation.Term,
                    Frequency = depreciation.Frequency
                };


            }

            return result;
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
            var item = await _assetRepository
                .AsReadOnly()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(AssetViewModel.Select(_mediaService))
                .FirstOrDefaultAsync();

            if (item == null)
                throw new NotFoundException("Asset not found");

            return item;
        }

        public async Task<PagedCollection<AssetViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            return await _assetRepository.ListAsync(null, AssetViewModel.Select(_mediaService), pagingOptions, searchOptions, cancellationToken);
        }

        public async Task<bool> CheckoutAsync(AssetCheckoutRequest request, CancellationToken cancellationToken = default)
        {
            List<Entities.Asset> asstes = new List<Entities.Asset>();
            if (request.AssetIds == null || request.AssetIds.Length <= 0)
                throw new NotFoundException("Asset not found");

            foreach (var assetId in request.AssetIds)
            {
                var entity = await _assetRepository
                    .AsQueryable()
                    .Include(x => x.AssetModel)
                    .FirstOrDefaultAsync(x => x.Id == assetId && !x.IsDeleted);

                if (entity == null)
                    throw new NotFoundException($"Asset({assetId}) not found");

                if (entity.CheckoutId != null)
                    throw new ValidationException($"Asset({assetId}) is already assigned.");

                asstes.Add(entity);
            }

            int result = 0;
            foreach (var entity in asstes)
            {

                var checkout = new AssetCheckout
                {
                    CheckoutDate = request.CheckoutDate,
                    ChekoutToAssetId = request.ChekoutToAssetId,
                    ChekoutToLocationId = request.ChekoutToLocationId,
                    ChekoutToUserId = request.ChekoutToUserId,
                    ExpectedChekinDate = request.ExpectedChekinDate
                };

                await _assetCheckoutRepository.AddAsync(checkout);
                await _unitOfWork.SaveChangesAsync();

                entity.CheckoutId = checkout.Id;
                result += await _unitOfWork.SaveChangesAsync(cancellationToken);

                var target = GetTarget(request.ChekoutToAssetId, request.ChekoutToUserId, request.ChekoutToLocationId);

                if (target.TargetId.HasValue)
                {
                    await _checkoutHistoryService.CreateAsync(new CheckoutHistoryCreateRequest
                    {
                        Action = AssetAction.Checkout,
                        ItemId = entity.Id,
                        ItemType = AssetType.Asset,
                        Note = request.Note,
                        TargetId = target.TargetId,
                        TargetType = target.TargetType
                    });

                    if (request.ChekoutToUserId.HasValue)
                    {
                        await _assetEmailService.SendEULAEmailAsync(request.ChekoutToUserId.Value, entity.AssetModel.CategoryId);
                    }
                }
            }

            return result > 0;
        }

        public async Task<bool> CheckinAsync(AssetCheckinRequest request, CancellationToken cancellationToken = default)
        {

            var asset = await _assetRepository
                .AsQueryable()
                .Include(x => x.Checkout)
                .FirstOrDefaultAsync(x => x.Id == request.AssetId && x.CheckoutId != null && !x.IsDeleted);

            if (asset == null)
                throw new NotFoundException("Asset not found");

            if (asset.Checkout == null)
                throw new NotFoundException("Checkout not found");

            if (request.Status.HasValue)
                asset.StatusId = request.Status.Value;

            var target = GetTarget(asset.Checkout.ChekoutToAssetId, asset.Checkout.ChekoutToUserId, asset.Checkout.ChekoutToLocationId);

            if (target.TargetId.HasValue)
            {
                await _checkoutHistoryService.CreateAsync(new CheckoutHistoryCreateRequest
                {
                    Action = AssetAction.Checkin,
                    ItemId = request.AssetId,
                    ItemType = AssetType.Asset,
                    Note = request.Note,
                    TargetId = target.TargetId,
                    TargetType = target.TargetType
                });
            }

            asset.CheckoutId = null;
            _assetCheckoutRepository.Remove(asset.Checkout);
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

        public async Task<PagedCollection<AssetLicenseListViewModel>> ListLicensesAsync(long assetId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var query = _licenseSeatRepository
                .AsReadOnly()
                .Where(x => x.IssuedToAssetId == assetId && !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new AssetLicenseListViewModel
                {
                    Id = x.Id,
                    Name = x.License.Name,
                    ProductKey = x.License.ProductKey
                })
                .ToListAsync(cancellationToken);

            var total = await query.Select(x => x.Id).CountAsync(cancellationToken);

            var result = new PagedCollection<AssetLicenseListViewModel>(items, total, pagingOptions);
            return result;
        }

        public async Task<AssetDashboardViewModel> GetDashboard(CancellationToken cancellationToken = default)
        {
            AssetDashboardViewModel model = new AssetDashboardViewModel();
            var now = DateTime.UtcNow.Date;

            model.AssetReturnAlert = 0;

            model.BatchWiseItemRequiredAndReceived = 0;

            string totalConsumableSql = @"select 
                        sum(c.Available) Available
                        from[asset].[Consumable] c
                       where c.IsDeleted = 0";
            long totalConsumable = await _dbConnection.ExecuteScalarAsync<long>(totalConsumableSql);

            model.CurrentStock = new AssetCurrentStockViewModel
            {
                Asset = await _assetRepository.Where(x => x.CheckoutId == null && !x.IsDeleted).CountAsync(),
                License = await _unitOfWork.GetRepository<LicenseSeat>().Where(x => x.IssuedToAssetId == null && x.IssuedToUserId == null && !x.IsDeleted).CountAsync(),
                Consumable = totalConsumable
            };

            string reorderAlerSql = @"with cte 
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
                        left join [asset].[Category] c on c.Id = i.CategoryId
                        where i.Available < i.MinQuantity
                        order by i.Code";
            model.ReorderAlert = await _dbConnection.QueryAsync<AssetReorderAlertViewModel>(reorderAlerSql);

            model.Requisition = 0;

            return await Task.FromResult(model);
        }

        private (long? TargetId, AssetType TargetType) GetTarget(long? assetId, long? userId, long? locationId)
        {
            long? targetId = assetId;
            AssetType targetType = AssetType.Asset;

            if (targetId == null)
            {
                targetType = AssetType.User;
                targetId = userId;
            }

            if (targetId == null)
            {
                targetType = AssetType.Location;
                targetId = locationId;
            }
            return (targetId, targetType);
        }

    }
}
