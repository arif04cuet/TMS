﻿using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface ISupplierService : IScopedService
    {
        Task<long> CreateAsync(SupplierCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(SupplierUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<SupplierViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<SupplierViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);


    }
}
