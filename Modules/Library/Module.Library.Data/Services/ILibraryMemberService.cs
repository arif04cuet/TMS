using Infrastructure;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Library.Data
{
    public interface ILibraryMemberService : IScopedService
    {
        Task<long> CreateFromUserAsync(LibraryMemberCreateFromUserRequest request, CancellationToken ct = default);

        Task<long> CreateAsync(LibraryMemberCreateRequest request, CancellationToken ct = default);

        Task<bool> DeleteAsync(long id, CancellationToken ct = default);

        Task<PagedCollection<LibraryMemberListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<LibraryMemberViewModel> GetAsync(long id);

        Task<bool> UpdateAsync(LibraryMemberUpdateRequest request, CancellationToken ct = default);

        Task<PagedCollection<IdNameViewModel>> GetCardsAsync(long memberId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default);
    }
}
