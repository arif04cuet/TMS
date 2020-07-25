using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IRoomService : IScopedService
    {
        Task<long> CreateAsync(RoomCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(RoomUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<RoomViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<RoomViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);
        Task<bool> DeleteImageAsync(long imageId, long? courseId, CancellationToken cancellationToken = default);
    }
}
