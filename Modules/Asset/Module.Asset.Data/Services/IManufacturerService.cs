using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface IManufacturerService : IScopedService
    {
        Task<long> CreateAsync(ManufacturerCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(ManufacturerUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<ManufacturerViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<ManufacturerViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);


    }
}
