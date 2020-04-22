using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Shared;
using Module.Library.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
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
        public readonly IRepository<BookIssue> _bookIssueRepository;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _bookRepository = _unitOfWork.GetRepository<Book>();
            _bookEditionRepository = _unitOfWork.GetRepository<BookEdition>();
            _bookItemRepository = _unitOfWork.GetRepository<BookItem>();
            _bookSubjecRepository = _unitOfWork.GetRepository<BookSubject>();
            _bookIssueRepository = _unitOfWork.GetRepository<BookIssue>();
        }

        #region Book
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

                var editions = request.ToBookEditions(newBook.Id);
                await _bookEditionRepository.AddRangeAsync(editions, ct);
                result += await _unitOfWork.SaveChangesAsync(ct);
            }

            return newBook.Id;
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
                    Description = x.Description,
                    Excerpt = x.Excerpt,
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
                        PublicationDate = x.PublicationDate
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
            book.Description = request.Description;
            book.Excerpt = request.Excerpt;
            book.LanguageId = request.Language;
            book.PublisherId = request.Publisher;

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            var book = await _bookRepository
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, false, ct);

            if (book == null)
                throw new NotFoundException(BOOK_NOT_FOUND);

            book.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        #endregion

        #region Book Item

        public async Task<long> CreateBookItemAsync(BookItemCreateRequest request, CancellationToken ct = default)
        {
            var items = request.IsbnAndBarcodes.Select(x => new BookItem
            {
                Barcode = x.Barcode,
                Isbn = x.Isbn,
                BookId = request.Book,
                DateOfPurchage = request.DateOfPurchase,
                FormatId = request.Format,
                PurchagePrice = request.PurchasePrice,
                EditionId = request.Edition,
                RackId = request.Rack,
                StatusId = request.Status
            });
            await _bookItemRepository.AddRangeAsync(items, ct);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result;
        }

        public async Task<long> UpdateBookItemAsync(BookItemUpdateRequest request, CancellationToken ct = default)
        {
            var item = await _bookItemRepository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (item == null)
                throw new NotFoundException(BOOK_ITEM_NOT_FOUND);

            request.MapTo(item);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return item.Id;
        }

        public async Task<bool> DeleteBookItemAsync(long bookItemId, CancellationToken ct = default)
        {
            var item = await _bookItemRepository.FirstOrDefaultAsync(x => x.Id == bookItemId && !x.IsDeleted);

            if (item == null)
                throw new NotFoundException(BOOK_ITEM_NOT_FOUND);

            item.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task<BookItemViewModel> GetBookItemAsync(long bookItemId)
        {
            var result = await _bookItemRepository
                .AsReadOnly()
                .Include(x => x.Book)
                .Include(x => x.Edition)
                .Select(x => new BookItemViewModel
                {
                    Id = x.Id,
                    Author = x.Book.Author != null ? new IdNameViewModel
                    {
                        Id = x.Book.AuthorId.Value,
                        Name = x.Book.Author.Name
                    } : null,
                    Description = x.Book.Description,
                    Language = x.Book.Language != null ? new IdNameViewModel
                    {
                        Id = x.Book.LanguageId,
                        Name = x.Book.Language.Name
                    } : null,
                    Title = x.Book.Title,
                    Publisher = x.Book.Publisher != null ? new IdNameViewModel
                    {
                        Id = x.Book.PublisherId.Value,
                        Name = x.Book.Publisher.Name
                    } : null,
                    Edition = x.Edition != null ? new BookEditionViewModel
                    {
                        Id = x.Edition.Id,
                        Edition = x.Edition.Edition,
                        EBookId = x.Edition.EBookId,
                        NumberOfCopy = x.Edition.NumberOfCopy,
                        NumberOfPage = x.Edition.NumberOfPage,
                        PublicationDate = x.Edition.PublicationDate
                    } : null,
                    Barcode = x.Barcode,
                    DateOfPurchase = x.DateOfPurchage,
                    PurchasePrice = x.PurchagePrice,
                    Format = x.Format != null ? new IdNameViewModel
                    {
                        Id = x.Format.Id,
                        Name = x.Format.Name
                    } : null,
                    Isbn = x.Isbn,
                    Rack = x.Rack != null ? new IdNameViewModel
                    {
                        Id = x.Rack.Id,
                        Name = x.Rack.Name
                    } : null,
                    Status = x.Status != null ? new IdNameViewModel
                    {
                        Id = x.Status.Id,
                        Name = x.Status.Name
                    } : null,
                    Book = x.Book != null ? new IdNameViewModel
                    {
                        Id = x.Book.Id,
                        Name = x.Book.Title
                    } : null
                })
                .FirstOrDefaultAsync(x => x.Id == bookItemId);

            if (result != null)
            {
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

        public async Task<PagedCollection<BookItemListViewModel>> ListBookItemsAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {

            var issues = _bookIssueRepository.AsReadOnly();
            var items = _bookItemRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var result = from item in items
                         join issue in issues on item.Id equals issue.BookItemId into data
                         from d in data.DefaultIfEmpty()
                         // where d.ActualReturnDate == null // currently issued book has no actual return date
                         select new BookItemListViewModel
                         {
                             Id = item.Id,
                             Isbn = item.Isbn,
                             Barcode = item.Barcode,
                             Title = item.Book.Title,
                             Author = item.Book.Author != null ? new IdNameViewModel
                             {
                                 Id = item.Book.Author.Id,
                                 Name = item.Book.Author.Name
                             } : null,
                             Publisher = item.Book.Publisher != null ? new IdNameViewModel
                             {
                                 Id = item.Book.Publisher.Id,
                                 Name = item.Book.Publisher.Name
                             } : null,
                             IssuedTo = d != null ? new IdNameViewModel
                             {
                                 Id = d.Member.Id,
                                 Name = d.Member.FullName
                             } : null,
                             Status = item.Status != null ? new IdNameViewModel
                             {
                                 Id = item.Status.Id,
                                 Name = item.Status.Name
                             } : null
                         };

            var _items = await result
                .ApplyPagination(pagingOptions)
                .ToListAsync();

            var total = await items.Select(x => x.Id).CountAsync();
            return new PagedCollection<BookItemListViewModel>(_items, total, pagingOptions);
        }

        public async Task<long> IssueBookItemAsync(BookItemIssueRequest request, CancellationToken ct = default)
        {
            // check book is available
            var item = await _bookItemRepository
                .FirstOrDefaultAsync(x => x.Id == request.BookItem && x.StatusId == BookStatusConstants.Available && !x.IsDeleted, false, ct);

            if (item == null)
                throw new ValidationException(BOOK_IS_NOT_AVAILABLE_FOR_ISSUE);

            // check if already issued to this user
            var issue = await _bookIssueRepository
                .FirstOrDefaultAsync(x => x.BookId == request.BookItem && x.MemberId == request.Member && x.MemberLibraryCardId == request.Card && x.ActualReturnDate == null && !x.IsDeleted, true, ct);

            if (issue != null)
                throw new ValidationException(BOOK_IS_ALREADY_ISSUED);

            var user = await _unitOfWork.GetRepository<LibraryMember>()
                .Where(x => x.Id == request.Member && !x.IsDeleted && !x.User.IsDeleted)
                .Select(x => new
                {
                    Id = x.UserId
                })
                .FirstOrDefaultAsync(ct);

            if (user == null)
                throw new ValidationException(LIBRARY_MEMBER_NOT_FOUND);

            var card = await _unitOfWork.GetRepository<MemberLibraryCard>()
                .AsQueryable()
                .Where(x => x.UserId == user.Id && x.Id == request.Card && !x.IsDeleted)
                .Select(x => new
                {
                    MaxIssueCount = x.LibraryCard.MaxIssueCount
                })
                .FirstOrDefaultAsync(ct);

            if (card == null)
                throw new ValidationException(LIBRARY_CARD_NOT_FOUND);

            var issueCount = await _bookIssueRepository
                .Where(x => x.MemberId == request.Member && x.MemberLibraryCardId == request.Card && x.ActualReturnDate != null && !x.IsDeleted)
                .Select(x => x.Id)
                .CountAsync(ct);

            if (issueCount >= card.MaxIssueCount)
                throw new ValidationException(ISSUE_QOUTA_EXCEEDS);

            issue = request.ToBookIssue();
            issue.MemberId = user.Id;
            await _bookIssueRepository.AddAsync(issue, ct);

            item.StatusId = BookStatusConstants.Loned;

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return issue.Id;
        }

        public async Task<bool> ReturnBookItemAsync(BookItemReturnRequest request, CancellationToken ct = default)
        {
            var issue = await _bookIssueRepository
                .AsQueryable()
                .Include(x => x.BookItem)
                .FirstOrDefaultAsync(x => x.BookItemId == request.BookItem && x.ActualReturnDate == null && !x.IsDeleted, ct);

            if (issue == null)
                throw new ValidationException(ITEM_NOT_FOUND);

            issue.ActualReturnDate = request.ActualReturnDate ?? DateTime.Now;
            issue.BookItem.StatusId = BookStatusConstants.Available;
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task<BookItemIssueViewModel> GetIssueAsync(long bookItemId)
        {
            var result = await _bookIssueRepository
                .AsReadOnly()
                .Where(x => x.BookItemId == bookItemId)
                .Select(x => new BookItemIssueViewModel
                {
                    Id = x.Id,
                    Book = new IdNameViewModel
                    {
                        Id = x.Book.Id,
                        Name = x.Book.Title
                    },
                    BookItem = new IdNameViewModel
                    {
                        Id = x.BookItem.Id,
                        Name = x.Book.Title
                    },
                    Card = new IdNameViewModel
                    {
                        Id = x.MemberLibraryCard.Id,
                        Name = x.MemberLibraryCard.CardNumber
                    },
                    IssueDate = x.IssueDate,
                    ReturnDate = x.ReturnDate,
                    Member = new IdNameViewModel
                    {
                        Id = x.Member.Id,
                        Name = x.Member.FullName
                    }
                })
                .FirstOrDefaultAsync();

            return result;
        }

        #endregion

        public async Task<PagedCollection<IdNameViewModel>> ListBookEditionsAsync(long bookId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var query = _bookEditionRepository
                .AsReadOnly()
                .Where(x => x.BookId == bookId && !x.IsDeleted);
            //.ApplySearch(searchOptions);

            var items = await query
                //.Include(x => x.Edition)
                .ApplyPagination(pagingOptions)
                .Select(x => new IdNameViewModel
                {
                    Id = x.Id,
                    Name = x.Edition
                })
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<IdNameViewModel>(items, total, pagingOptions);
        }

    }
}
