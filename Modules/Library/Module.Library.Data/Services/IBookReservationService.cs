using Infrastructure;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Library.Data
{
    public interface IBookReservationService : IScopedService
    {
        Task<long> CreateAsync(BookReservationCreateRequest request, CancellationToken ct = default);

        Task<bool> DeleteAsync(long id, CancellationToken ct = default);

        Task<PagedCollection<BookReservationListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<BookReservationListViewModel> GetAsync(long id);

        Task<bool> UpdateAsync(BookReservationUpdateRequest request, CancellationToken ct = default);

        Task<bool> CancelAsync(long id, CancellationToken ct = default);

        Task<bool> IssueAsync(long reservationId, CancellationToken ct = default);

        Task<PagedCollection<IdNameViewModel>> ListAssignableBookItemsAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);
    }
}
