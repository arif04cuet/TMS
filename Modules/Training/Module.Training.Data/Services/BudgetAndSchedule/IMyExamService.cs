using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IMyExamService : IScopedService
    {
        Task<long> SubmitAnswerAsync(SubmitExamAnswerRequest request, CancellationToken cancellationToken = default);

        Task<ExamViewModel> Get(long classRoutineId, CancellationToken cancellationToken = default);

        Task<PagedCollection<MyExamListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
