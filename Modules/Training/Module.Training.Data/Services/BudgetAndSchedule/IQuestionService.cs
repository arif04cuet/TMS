using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IQuestionService : IScopedService
    {
        Task<long> CreateAsync(QuestionCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(QuestionUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<QuestionViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<QuestionViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
