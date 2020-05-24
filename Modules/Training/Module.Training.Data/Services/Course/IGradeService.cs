using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IGradeService : IScopedService
    {
        Task<long> CreateAsync(GradeCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(GradeUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<GradeViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<GradeViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
