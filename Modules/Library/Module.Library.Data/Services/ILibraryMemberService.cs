using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Library.Data
{
    public interface ILibraryMemberService : IScopedService
    {
        Task<long> CreateAsync(LibraryMemberCreateRequest request, CancellationToken ct = default);

        Task<bool> DeleteAsync(long id, CancellationToken ct = default);

        Task<PagedCollection<LibraryMemberListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<LibraryMemberViewModel> GetAsync(long id);

        Task<bool> UpdateAsync(LibraryMemberUpdateRequest request, CancellationToken ct = default);
    }
}
