using Infrastructure;
using Module.Library.Data.ViewModels;
using Module.Library.ViewModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Library.Services
{
    public interface IBookService : IScopedService
    {
        Task<long> CreateAsync(BookCreateRequest request, CancellationToken ct = default);

        Task<bool> DeleteAsync(long id, CancellationToken ct = default);

        Task<IEnumerable<BookListViewModel>> ListAsync();

        Task<BookViewModel> GetAsync(long id);

        Task<bool> UpdateAsync(BookUpdateRequest request, CancellationToken ct = default);
    }
}
