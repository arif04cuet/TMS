using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IEvaluationMethodService : IScopedService
    {
        Task<long> CreateAsync(EvaluationMethodCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(EvaluationMethodUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<EvaluationMethodViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<EvaluationMethodViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
