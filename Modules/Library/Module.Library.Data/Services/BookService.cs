using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Library.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using static Module.Core.Shared.MessageConstants;

namespace Module.Library.Data
{
    public class BookService : IBookService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<Book> _bookRepository;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _bookRepository = _unitOfWork.GetRepository<Book>();
        }

        public async Task<long> CreateAsync(BookCreateRequest request, CancellationToken ct = default)
        {
            Book newBook = request.ToBook();
            await _bookRepository.AddAsync(newBook, ct);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return newBook.Id;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            var book = new Book { Id = id };
            _bookRepository.Remove(book);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task<PagedCollection<BookListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var query = _bookRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new BookListViewModel
                {
                    Id = x.Id
                })
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<BookListViewModel>(items, total, pagingOptions);
        }

        public async Task<BookViewModel> GetAsync(long id)
        {
            var result = _bookRepository
                .AsReadOnly()
                .Select(x => new BookViewModel
                {
                    Id = x.Id
                })
                .FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<bool> UpdateAsync(BookUpdateRequest request, CancellationToken ct = default)
        {
            var book = await _bookRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (book == null)
                throw new NotFoundException(BOOK_NOT_FOUND);

            book.Title = request.Title;

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

    }
}
