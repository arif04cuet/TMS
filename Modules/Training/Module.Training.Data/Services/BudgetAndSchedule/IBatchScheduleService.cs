using Infrastructure;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IBatchScheduleService : IScopedService
    {
        Task<long> CreateAsync(BatchScheduleCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(BatchScheduleUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<BatchScheduleViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<BatchScheduleViewModel>> ListAsync(string scheduleStatus, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<PagedCollection<IdNameViewModel>> ListDropdownAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<PagedCollection<BatchScheduleParticipantViewModel>> ParticipantListAsync(long batchScheduleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<PagedCollection<IdNameViewModel>> ListModuleAsync(long batchScheduleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<PagedCollection<IdNameViewModel>> EvaluationMethodListAsync(long batchScheduleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<byte[]> GenerateHonorariumSheetAsync(long batchScheduleId, CancellationToken cancellationToken = default);

    }
}
