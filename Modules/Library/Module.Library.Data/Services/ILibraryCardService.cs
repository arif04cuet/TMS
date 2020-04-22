using Infrastructure;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Library.Data
{
    public interface ILibraryCardService : IScopedService
    {
        Task<long> CreateAsync(LibraryCardCreateRequest request, CancellationToken ct = default);

        Task<bool> DeleteAsync(long id, CancellationToken ct = default);

        Task<PagedCollection<LibraryCardListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<LibraryCardViewModel> GetAsync(long id);

        Task<bool> UpdateAsync(LibraryCardUpdateRequest request, CancellationToken ct = default);
    }
}
