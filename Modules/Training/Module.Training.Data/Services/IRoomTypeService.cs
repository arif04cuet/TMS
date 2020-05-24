using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IRoomTypeService : IScopedService
    {
        Task<long> CreateAsync(RoomTypeCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(RoomTypeUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<RoomTypeViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<RoomTypeViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);
    }
}
