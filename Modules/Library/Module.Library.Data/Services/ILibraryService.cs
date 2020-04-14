using Infrastructure;
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

        Task<BookViewModel> GetAsync(long id);

        Task<bool> UpdateAsync(LibraryUpdateRequest request, CancellationToken ct = default);
    }
}
