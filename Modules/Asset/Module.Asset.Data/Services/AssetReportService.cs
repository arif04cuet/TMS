using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class AssetReportService : IAssetReportService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CheckoutHistory> _historyRepository;
        private readonly ICheckoutHistoryService _checkoutHistoryService;

        public AssetReportService(
            IUnitOfWork unitOfWork,
            ICheckoutHistoryService checkoutHistoryService)
        {
            _unitOfWork = unitOfWork;
            _checkoutHistoryService = checkoutHistoryService;
            _historyRepository = _unitOfWork.GetRepository<CheckoutHistory>();
        }

        public Task<PagedCollection<CheckoutHistoryListViewModel>> ActivityLogAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            return _checkoutHistoryService.ListAsync(null, null, pagingOptions, searchOptions, cancellationToken);
        }

        public async Task<PagedCollection<DepreciationReportViewModel>> DepreciationReportAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var assets = _unitOfWork.GetRepository<Entities.Asset>()
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var results = assets
                .ApplyPagination(pagingOptions)
                .Select(x => new DepreciationReportViewModel
                {
                    Location = x.LocationId != null ? x.Location.OfficeName : "",
                    Asset = x.Name,
                    CheckedOut = x.CheckoutId != null ? new AssetCheckoutViewModel
                    {
                        CheckoutDate = x.Checkout.CheckoutDate,
                        ExpectedChekinDate = x.Checkout.ExpectedChekinDate,
                        ChekoutToAsset = x.Checkout.ChekoutToAssetId != null ? new IdNameViewModel
                        {
                            Id = x.Checkout.ChekoutToAsset.Id,
                            Name = x.Checkout.ChekoutToAsset.Name
                        } : null,
                        ChekoutToUser = x.Checkout.ChekoutToUserId != null ? new IdNameViewModel
                        {
                            Id = x.Checkout.ChekoutToUser.Id,
                            Name = x.Checkout.ChekoutToUser.FullName
                        } : null,
                        ChekoutToLocation = x.Checkout.ChekoutToLocationId != null ? new IdNameViewModel
                        {
                            Id = x.Checkout.ChekoutToLocation.Id,
                            Name = x.Checkout.ChekoutToLocation.OfficeName
                        } : null
                    } : null,
                    Cost = x.PurchaseCost.ToString(),
                    Purchased = x.PurchaseDate
                });

            var total = await assets.Select(x => x.Id).CountAsync(cancellationToken);
            var items = await results.ToListAsync(cancellationToken);

            var result = new PagedCollection<DepreciationReportViewModel>(items, total, pagingOptions);
            return result;
        }

        public async Task<PagedCollection<LicenseReportViewModel>> LicenseReportAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var query = _unitOfWork.GetRepository<License>()
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new LicenseReportViewModel
                {
                    Depreciation = x.Depreciation.Name,
                    License = x.Name,
                    ProductKey = x.ProductKey,
                    Seats = x.Seats,
                    PurchaseDate = x.PurchaseDate,
                    PurchaseCost = x.PurchaseCost.ToString(),
                    ExpirationDate = x.ExpireDate,
                    RemainingSeats = x.Available.Value,
                    Value = ((long)((x.PurchaseCost / x.Depreciation.Term) * (DateTime.UtcNow - x.PurchaseDate).TotalDays)).ToString()
                })
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<LicenseReportViewModel>(items, total, pagingOptions);
            return result;
        }

        public async Task<PagedCollection<MaintenanceReportViewModel>> MaintenanceReportAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var query = _unitOfWork.GetRepository<AssetMaintenance>()
                .AsReadOnly()
                .Where(x => x.CompletionDate != null && !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new MaintenanceReportViewModel
                {
                    AssetMaintenanceType = x.Type.ToString(),
                    AssetName = x.Asset.Name,
                    CompletionDate = x.CompletionDate.Value,
                    Cost = x.Cost.ToString(),
                    StartDate = x.StartDate,
                    Supplier = x.Supplier.Name,
                    Title = x.Title,
                    AssetMaintenanceTime = (long)(x.StartDate - x.CompletionDate.Value).TotalDays
                })
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<MaintenanceReportViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
