using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Shared;
using Module.Library.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Collections.Generic;
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
        public readonly IRepository<BookEdition> _bookEditionRepository;
        public readonly IRepository<BookItem> _bookItemRepository;
        public readonly IRepository<BookSubject> _bookSubjecRepository;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _bookRepository = _unitOfWork.GetRepository<Book>();
            _bookEditionRepository = _unitOfWork.GetRepository<BookEdition>();
            _bookItemRepository = _unitOfWork.GetRepository<BookItem>();
            _bookSubjecRepository = _unitOfWork.GetRepository<BookSubject>();
        }

        public async Task<long> CreateAsync(BookCreateRequest request, CancellationToken ct = default)
        {
            // Create book
            var newBook = request.ToBook();
            await _bookRepository.AddAsync(newBook, ct);
            var result = await _unitOfWork.SaveChangesAsync(ct);

            // Subjects
            if (request.Subjects != null)
            {
                var subjects = request.ToBookSubjects(newBook.Id);
                await _bookSubjecRepository.AddRangeAsync(subjects, ct);
            }

            // Create edition
            if (request.Editions != null)
            {
                List<BookItem> bookItems = new List<BookItem>();

                foreach (var editionRequest in request.Editions)
                {
                    var edition = request.ToBookEdition(editionRequest, newBook.Id);
                    await _bookEditionRepository.AddAsync(edition, ct);
                    result += await _unitOfWork.SaveChangesAsync(ct);

                    // Create book items
                    for (int i = 0; i < editionRequest.NumberOfCopy; i++)
                    {
                        bookItems.Add(new BookItem
                        {
                            BookId = newBook.Id,
                            EditionId = edition.Id
                        });
                    }
                }

                await _bookItemRepository.AddRangeAsync(bookItems, ct);
                result += await _unitOfWork.SaveChangesAsync(ct);
            }

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
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Author = x.Author != null ? new IdNameViewModel
                    {
                        Id = x.Author.Id,
                        Name = x.Author.Name
                    } : null,
                    Publisher = x.Publisher != null ? new IdNameViewModel
                    {
                        Id = x.Publisher.Id,
                        Name = x.Publisher.Name
                    } : null
                })
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<BookListViewModel>(items, total, pagingOptions);
        }

        public async Task<BookViewModel> GetAsync(long id)
        {
            var result = await _bookRepository
                .AsReadOnly()
                .Select(x => new BookViewModel
                {
                    Id = x.Id,
                    Author = x.Author != null ? new IdNameViewModel
                    {
                        Id = x.AuthorId.Value,
                        Name = x.Author.Name
                    } : null,
                    Binding = x.Binding,
                    Description = x.Description,
                    Excerpt = x.Excerpt,
                    Isbn = x.Isbn,
                    Language = x.Language != null ? new IdNameViewModel
                    {
                        Id = x.LanguageId,
                        Name = x.Language.Name
                    } : null,
                    Title = x.Title,
                    Publisher = x.Publisher != null ? new IdNameViewModel
                    {
                        Id = x.PublisherId.Value,
                        Name = x.Publisher.Name
                    } : null
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
            {
                // Editions
                var editions = await _bookEditionRepository
                    .Where(x => x.BookId == result.Id)
                    .Select(x => new BookEditionViewModel
                    {
                        EBookId = x.EBookId,
                        Edition = x.Edition,
                        NumberOfCopy = x.NumberOfCopy,
                        NumberOfPage = x.NumberOfPage,
                        PublicationDate = x.PublicationDate,
                        PurchagePrice = x.PurchagePrice,
                        RentalPrice = x.RentalPrice
                    })
                    .ToListAsync();
                result.Editions = editions;

                // Subjects
                var subjects = await _bookSubjecRepository
                    .Where(x => x.BookId == result.Id)
                    .Select(x => new IdNameViewModel
                    {
                        Id = x.SubjectId,
                        Name = x.Subject.Name
                    })
                    .ToListAsync();

                result.Subjects = subjects;
            }

            return result;
        }

        public async Task<bool> UpdateAsync(BookUpdateRequest request, CancellationToken ct = default)
        {
            var book = await _bookRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (book == null)
                throw new NotFoundException(BOOK_NOT_FOUND);

            book.Title = request.Title;
            book.AuthorId = request.Author;
            book.Binding = request.Binding;
            book.Description = request.Description;
            book.Excerpt = request.Excerpt;
            book.Isbn = request.Isbn;
            book.LanguageId = request.Language;
            book.PublisherId = request.Publisher;

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

    }
}
