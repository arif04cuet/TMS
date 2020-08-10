using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IBatchScheduleAllocationService : IScopedService
    {
        Task<long> CreateAsync(BatchScheduleAllocationCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(BatchScheduleAllocationUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateStatusAsync(BatchScheduleAllocationUpdateStatusRequest request, CancellationToken cancellationToken = default);

        Task<bool> MigrateToNextBatchAsync(MigrateToNextBatchRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<BatchScheduleAllocationViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<BatchScheduleAllocationViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<byte[]> ExportAllocationAsync(ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<byte[]> DownloadCertificateAsync(long batchScheduleAllocationId, CancellationToken cancellationToken = default);

    }
}
