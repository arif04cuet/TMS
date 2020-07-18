using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IBatchScheduleGalleryService : IScopedService
    {
        Task<BatchScheduleGalleryItemViewModel> CreateAsync(BatchScheduleGalleryItemCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long batchScheduleId, long galleryItemId, CancellationToken cancellationToken = default);

        Task<BatchScheduleGalleryItemViewModel> Get(long batchScheduleId, long galleryItemId, CancellationToken cancellationToken = default);

        Task<PagedCollection<BatchScheduleGalleryItemViewModel>> ListAsync(long batchScheduleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);
    }
}
