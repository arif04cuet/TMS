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

        Task<PagedCollection<LibraryMemberCardListViewModel>> ListMemberCardsAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<LibraryMemberViewModel> GetAsync(long id);

        Task<bool> UpdateAsync(LibraryMemberUpdateRequest request, CancellationToken ct = default);

        Task<PagedCollection<LibraryMemberListViewModel>> ListMemberRequestAsync(bool? isApproved, IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<long> CreateRequestAsync(LibraryMemberRequestCreateRequest request, CancellationToken ct = default);

        Task<long> ApproveMemberAsync(LibraryMemberApproveCreateRequest request, CancellationToken ct = default);
    }
}
