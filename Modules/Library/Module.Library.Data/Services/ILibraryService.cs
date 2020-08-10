using Infrastructure;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Library.Data
{
    public interface ILibraryService : IScopedService
    {
        Task<long> CreateAsync(LibraryCreateRequest request, CancellationToken ct = default);

        Task<bool> DeleteAsync(long id, CancellationToken ct = default);

        Task<PagedCollection<LibraryListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<PagedCollection<IdNameViewModel>> ListLibrarianAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<LibraryViewModel> GetAsync(long id);

        Task<LibraryCountViewModel> GetCountsAsync();

        Task<bool> UpdateAsync(LibraryUpdateRequest request, CancellationToken ct = default);

        Task<PagedCollection<FineListViewModel>> ListFineAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);
    }
}
