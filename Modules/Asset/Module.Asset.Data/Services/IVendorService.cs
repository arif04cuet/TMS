using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface IVendorService : IScopedService
    {
        Task<long> CreateAsync(VendorCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(VendorUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long vendorId, CancellationToken cancellationToken = default);

        Task<VendorViewModel> Get(long vendorId, CancellationToken cancellationToken = default);

        Task<PagedCollection<VendorListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);


    }
}
