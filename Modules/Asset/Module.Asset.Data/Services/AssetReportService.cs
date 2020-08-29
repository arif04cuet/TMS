using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Module.Core.Data;
using System.Linq.Expressions;

namespace Module.Asset.Data
{
    public class AssetReportService : IAssetReportService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CheckoutHistory> _historyRepository;
        private readonly ICheckoutHistoryService _checkoutHistoryService;
        private readonly IDbConnection _dbConnection;

        public AssetReportService(
            IUnitOfWork unitOfWork,
            ICheckoutHistoryService checkoutHistoryService)
        {
            _unitOfWork = unitOfWork;
            _dbConnection = _unitOfWork.GetConnection();
            _checkoutHistoryService = checkoutHistoryService;
            _historyRepository = _unitOfWork.GetRepository<CheckoutHistory>();
        }

        public Task<PagedCollection<CheckoutHistoryListViewModel>> ActivityLogAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            return _checkoutHistoryService.ListAsync(null, null, pagingOptions, searchOptions, cancellationToken);
        }

        public async Task<PagedCollection<DepreciationReportViewModel>> DepreciationReportAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var sql = $@"with cte as (
                        select max(d2.CreatedAt) CreatedAt, count(*) count from [asset].[AssetDepreciationRevision] d2
                        group by d2.AssetId
                        order by max(d2.CreatedAt)
                        offset {pagingOptions?.Offset ?? 0} rows fetch next {pagingOptions?.Limit ?? 20} rows only)
                        select a.Name AssetName, a.Id AssetId, d.EOL, d.Id DepreciationId,
                        a.PurchaseCost Price, 12 DepreciationFrequency,
                        d.RatePerFrequency DepreciationRate,
                        d.ValuePerFrequency DepreciationValue,
                        case when cte.count > 1 then 'Revised' else '1st time' end as Status
                        from cte
                        left join [asset].[AssetDepreciationRevision] d on d.CreatedAt = cte.CreatedAt
                        left join [asset].[Asset] a on a.Id = d.AssetId";

            var totalSql = @"with cte as (
                        select d2.AssetId from [asset].[AssetDepreciationRevision] d2
                        group by d2.AssetId)
                        select count(*) from cte";

            var items = await _dbConnection.QueryAsync<DepreciationReportViewModel>(sql);
            int total = await _dbConnection.ExecuteScalarAsync<int>(totalSql);

            var result = new PagedCollection<DepreciationReportViewModel>(items, total, pagingOptions);
            return result;
        }

        public async Task<PagedCollection<DepreciationScheduleReportViewModel>> DepreciationScheduleReportAsync(long? assetId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var query = _unitOfWork
                .GetRepository<AssetDepreciationSchedule>()
                .AsReadOnly()
                .Where(x => !x.IsDeleted);

            if (assetId.HasValue)
            {
                query = query.Where(x => x.AssetId == assetId);
            }
            query = query.OrderBy(x => x.CreatedAt).ApplySearch(searchOptions);
            var total = await query.Select(x => x.Id).CountAsync();
            var items = await query
                .Select(DepreciationScheduleReportViewModel.Select())
                .ApplyPagination(pagingOptions)
                .ToListAsync();

            var result = new PagedCollection<DepreciationScheduleReportViewModel>(items, total, pagingOptions);

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
