using Infrastructure;
using Infrastructure.Data;
using Module.Library.Data.ViewModels;
using Module.Library.Entities;
using Module.Library.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Library.Services
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

        public async Task<IEnumerable<BookListViewModel>> ListAsync()
        {
            var result = _bookRepository
                .AsReadOnly()
                .Select(x => new BookListViewModel
                {
                    Id = x.Id
                });
            return await Task.FromResult(result);
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
                throw new NotFoundException($"Book {request.Id} not found");

            book.Title = request.Title;

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

    }
}
