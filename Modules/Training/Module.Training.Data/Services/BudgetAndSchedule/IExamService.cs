using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IExamService : IScopedService
    {
        Task<long> CreateAsync(ExamCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(ExamUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default);

        Task<ExamViewModel> Get(long classRoutineId, CancellationToken cancellationToken = default);

        Task<PagedCollection<ExamViewModel>> ListAsync(long batchScheduleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<long> UpdateMarksAsync(ExamMarkUpdateRequest request, CancellationToken cancellationToken = default);

        Task<PagedCollection<ExamParticipantViewRequest>> ListParticipantAsync(long batchScheduleId, long examId);

    }
}
