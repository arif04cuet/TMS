using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface IRequisitionService : IScopedService
    {
        Task<long> CreateAsync(RequisitionCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(RequisitionUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<RequisitionViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<RequisitionListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);
    }
}
