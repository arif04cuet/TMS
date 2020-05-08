using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
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
        public readonly IBarcodeService _barcodeService;
        public readonly IAppService _appService;
        public readonly IMediaService _mediaService;

        public BookService(
            IUnitOfWork unitOfWork,
            IBarcodeService barcodeService,
            IAppService appService,
            IMediaService mediaService)
        {
            _mediaService = mediaService;
            _appService = appService;
            _barcodeService = barcodeService;
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

            await _mediaService.UseAsync(request.MediaId);

            // Subjects
            if (request.Subjects != null)
            {
                var subjects = request.ToBookSubjects(newBook.Id);
                await _bookSubjecRepository.AddRangeAsync(subjects, ct);
            }

            // Create edition
            if (request.Editions != null)
            {
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
                    Isbn = x.Isbn,
                    Description = x.Description,
                    Author = IdNameViewModel.Map(x.Author),
                    Publisher = IdNameViewModel.Map(x.Publisher),
                    Photo = _mediaService.GetFullUrl(x.Media)
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
                    Isbn = x.Isbn,
                    Author = IdNameViewModel.Map(x.Author),
                    Description = x.Description,
                    Excerpt = x.Excerpt,
                    Language = IdNameViewModel.Map(x.Language),
                    Title = x.Title,
                    Publisher = IdNameViewModel.Map(x.Publisher),
                    Photo = _mediaService.GetFullUrl(x.Media)
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
            {
                // Editions
                var editions = await _bookEditionRepository
                    .Where(x => x.BookId == result.Id)
                    .Select(x => new BookEditionViewModel
                    {
                        Id = x.Id,
                        EBookId = x.EBookId,
                        Edition = x.Edition,
                        NumberOfCopy = x.NumberOfCopy,
                        NumberOfPage = x.NumberOfPage,
                        PublicationDate = x.PublicationDate
                    })
                    .ToListAsync();
                result.Editions = editions;

                // Subjects
                var subjects = await _bookSubjecRepository.MatchAsync(new SubjectsByBookIdCriteria(result.Id));

                result.Subjects = subjects;
            }

            return result;
        }

        public async Task<bool> UpdateAsync(BookUpdateRequest request, CancellationToken ct = default)
        {
            var book = await _bookRepository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (book == null)
                throw new NotFoundException(BOOK_NOT_FOUND);

            book.Title = request.Title;
            book.Isbn = request.Isbn;
            book.AuthorId = request.Author;
            book.Description = request.Description;
            book.Excerpt = request.Excerpt;
            book.LanguageId = request.Language;
            book.PublisherId = request.Publisher;

            if(request.MediaId.HasValue && book.MediaId != request.MediaId)
            {
                // photo changed
                long? oldMediaId = book.MediaId;
                book.MediaId = request.MediaId;
                await _mediaService.UseAsync(request.MediaId.Value);
                _ = _mediaService.DeleteMediaAsync(oldMediaId);
            }

            foreach (var edition in request.Editions)
            {
                if (edition.Id.HasValue)
                {
                    // update
                    var dbEdition = await _bookEditionRepository
                        .FirstOrDefaultAsync(x => x.Id == edition.Id && !x.IsDeleted);
                    if (dbEdition != null)
                    {
                        edition.MapTo(dbEdition);
                    }
                }
                else
                {
                    // new
                    var newEdition = edition.ToBookBookEdition(book.Id);
                    await _bookEditionRepository.AddAsync(newEdition);
                }
            }

            // delete edition
            var requestBookEditions = request.Editions.Where(x => x.Id.HasValue).Select(x => (long)x.Id);
            var editionToBeDelete = await _bookEditionRepository
                .Where(x => x.BookId == book.Id && !requestBookEditions.Contains(x.Id))
                .ToListAsync();

            _bookEditionRepository.RemoveRange(editionToBeDelete);

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
            List<BookItem> items = new List<BookItem>();
            for (int i = 0; i < request.NumberOfCopy; i++)
            {
                items.Add(new BookItem
                {
                    BookId = request.Book,
                    DateOfPurchage = request.DateOfPurchase,
                    FormatId = request.Format,
                    PurchagePrice = request.PurchasePrice,
                    EditionId = request.Edition,
                    RackId = request.Rack,
                    StatusId = request.Status,
                    Barcode = _barcodeService.Generate()
                });
            }
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
                    Author = IdNameViewModel.Map(x.Book.Author),
                    Description = x.Book.Description,
                    Language = IdNameViewModel.Map(x.Book.Language),
                    Title = x.Book.Title,
                    Publisher = IdNameViewModel.Map(x.Book.Publisher),
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
                    Format = IdNameViewModel.Map(x.Format),
                    Rack = IdNameViewModel.Map(x.Rack),
                    Status = IdNameViewModel.Map(x.Status),
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
                var subjects = await _bookSubjecRepository.MatchAsync(new SubjectsByBookIdCriteria(result.Id));

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
                .ApplySearch(searchOptions)
                .OrderBy(x => x.Book.Title);

            //var result = from item in items
            //             join issue in issues on item.Id equals issue.BookItemId into data
            //             from d in data.DefaultIfEmpty()
            // where d.ActualReturnDate == null // currently issued book has no actual return date
            var result = items.Select(x => new BookItemListViewModel
            {
                Id = x.Id,
                Isbn = x.Book.Isbn,
                Barcode = x.Barcode,
                Title = x.Book.Title,
                Author = IdNameViewModel.Map(x.Book.Author),
                Publisher = IdNameViewModel.Map(x.Book.Publisher),
                IssuedTo = x.IssuedToId != null ? new IdNameViewModel
                {
                    Id = x.IssuedTo.Id,
                    Name = x.IssuedTo.FullName
                } : null,
                Status = IdNameViewModel.Map(x.Status),
                IssueDate = x.CurrentIssue.IssueDate,
                ReturnDate = x.CurrentIssue.ReturnDate
            });

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

            var card = await _unitOfWork.GetRepository<LibraryCard>()
                .AsReadOnly()
                .Include(x => x.Member).ThenInclude(x => x.Status)
                .Include(x => x.CardStatus)
                .Where(x => x.Id == request.Card && !x.IsDeleted)
                .FirstOrDefaultAsync(ct);

            if (card == null)
                throw new ValidationException(LIBRARY_CARD_NOT_FOUND);

            if (card.CardStatusId != LibraryCardStatusConstants.Active)
                throw new ValidationException($"Card is {card.CardStatus.Name}");

            if (card.Member.StatusId != StatusConstants.Active || card.Member.StatusId != StatusConstants.Approved)
                throw new ValidationException($"Member is {card.Member.Status.Name}");

            // check if already issued to this user
            var issue = await _bookIssueRepository
                .FirstOrDefaultAsync(x => x.BookId == request.BookItem && x.MemberId == card.MemberId && x.LibraryCardId == request.Card && x.ActualReturnDate == null && !x.IsDeleted, true, ct);

            if (issue != null)
                throw new ValidationException(BOOK_IS_ALREADY_ISSUED);

            // check member library card max issue count
            var issueCount = await _bookIssueRepository
                .AsReadOnly()
                .Where(x => x.MemberId == card.MemberId && x.LibraryCardId == request.Card && x.ActualReturnDate != null && !x.IsDeleted)
                .Select(x => x.Id)
                .CountAsync(ct);

            if (issueCount >= card.MaxIssueCount)
                throw new ValidationException(ISSUE_QOUTA_EXCEEDS);

            // add book issue
            issue = request.ToBookIssue((long)card.MemberId);
            await _bookIssueRepository.AddAsync(issue, ct);

            // mark book item as loaned
            item.StatusId = BookStatusConstants.Loned;
            item.IssuedToId = (long)card.MemberId;

            var result = await _unitOfWork.SaveChangesAsync(ct);

            // set book item current issue reference
            item.CurrentIssueId = issue.Id;
            result += await _unitOfWork.SaveChangesAsync(ct);

            return issue.Id;
        }

        public async Task<bool> ReturnBookItemAsync(BookItemReturnRequest request, CancellationToken ct = default)
        {
            var bookItem = await _bookItemRepository
                .AsQueryable()
                .Include(x => x.CurrentIssue)
                .FirstOrDefaultAsync(x => x.Id == request.BookItem && !x.IsDeleted, ct);

            if (bookItem == null || bookItem.CurrentIssue == null)
                throw new ValidationException(ITEM_NOT_FOUND);

            DateTime date = request.ActualReturnDate ?? DateTime.UtcNow;
            Fine fine = null;
            int result = 0;
            var checkFine = CheckFineAndCaculateAmount(bookItem.CurrentIssue.ReturnDate, date);
            if (checkFine.IsFined)
            {
                fine = new Fine();
                if (request.Fine != null)
                {
                    var dueAmount = checkFine.FineAmount - request.Fine.Amount;
                    fine.DueAmount = (float)dueAmount;
                    fine.Amount = (float)checkFine.FineAmount;
                    fine.PaymentDate = DateTime.Now;
                    fine.LibraryId = bookItem.LibraryId;
                }
                await _unitOfWork.GetRepository<Fine>().AddAsync(fine);
                result += await _unitOfWork.SaveChangesAsync(ct);
            }

            // TODO: check this book has reservation request
            // if reservation request, then reserver it

            bookItem.CurrentIssue.ActualReturnDate = date;
            bookItem.StatusId = BookStatusConstants.Available;
            if (fine != null)
            {
                bookItem.CurrentIssue.FineId = fine.Id;
            }
            result += await _unitOfWork.SaveChangesAsync(ct);

            if (request.IsRenew)
            {
                // new issue
                var renew = new BookIssue
                {
                    BookItemId = bookItem.Id,
                    BookId = bookItem.BookId,
                    IssueDate = DateTime.Now,
                    LibraryId = bookItem.LibraryId,
                    MemberId = bookItem.CurrentIssue.MemberId,
                    LibraryCardId = bookItem.CurrentIssue.LibraryCardId,
                    ReturnDate = request.NextReturnDate
                };
                await _bookIssueRepository.AddAsync(renew);
                result += await _unitOfWork.SaveChangesAsync(ct);

                bookItem.CurrentIssueId = renew.Id;
                bookItem.IssuedToId = renew.MemberId;
            }
            else
            {
                bookItem.IssuedToId = null;
                bookItem.CurrentIssueId = null;
            }

            result += await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task<BookItemCheckFineViewModel> CheckFineAsync(BookItemReturnRequest request, CancellationToken ct = default)
        {
            var bookItem = await _bookItemRepository
                .AsReadOnly()
                .Include(x => x.CurrentIssue)
                .FirstOrDefaultAsync(x => x.Id == request.BookItem && !x.IsDeleted, ct);

            if (bookItem == null || bookItem.CurrentIssue == null)
                throw new ValidationException(ISSUE_NOT_FOUND);

            DateTime date = request.ActualReturnDate ?? DateTime.UtcNow;
            var fine = CheckFineAndCaculateAmount(bookItem.CurrentIssue.ReturnDate, date);
            if (fine.IsFined)
            {
                return new BookItemCheckFineViewModel
                {
                    IsFined = true,
                    FineDays = fine.FineDays,
                    FineAmount = fine.FineAmount
                };
            }
            return default;
        }

        public async Task<BookItemIssueViewModel> GetIssueAsync(long bookItemId)
        {
            var result = await _bookItemRepository
                .AsReadOnly()
                .Where(x => x.Id == bookItemId)
                .Include(x => x.CurrentIssue)
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
                        Id = x.Id,
                        Name = x.Book.Title
                    },
                    Card = new IdNameViewModel
                    {
                        Id = x.CurrentIssue.LibraryCard.Id,
                        Name = x.CurrentIssue.LibraryCard.Barcode
                    },
                    IssueDate = x.CurrentIssue.IssueDate,
                    ReturnDate = x.CurrentIssue.ReturnDate,
                    Member = new IdNameViewModel
                    {
                        Id = x.CurrentIssue.Member.Id,
                        Name = x.CurrentIssue.Member.FullName
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

        public async Task<PagedCollection<BookIssueListViewModel>> ListIssueAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {

            var query = _bookIssueRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var result = await query
                .Select(x => new BookIssueListViewModel
                {
                    Id = x.Id,
                    Isbn = x.Book.Isbn,
                    Title = x.Book.Title,
                    Author = IdNameViewModel.Map(x.Book.Author),
                    IssuedTo = x.Member != null ? new IdNameViewModel
                    {
                        Id = x.Member.Id,
                        Name = x.Member.FullName
                    } : null,
                    ActualReturnDate = x.ActualReturnDate,
                    IssueDate = x.IssueDate,
                    ReturnDate = x.ReturnDate
                })
                .ApplyPagination(pagingOptions)
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<BookIssueListViewModel>(result, total, pagingOptions);
        }


        private (bool IsFined, double FineDays, double FineAmount) CheckFineAndCaculateAmount(DateTime? issueReturnDate, DateTime? actualReturnDate)
        {
            if (actualReturnDate.HasValue && issueReturnDate.HasValue && actualReturnDate > issueReturnDate)
            {
                var days = (actualReturnDate.Value.Date - issueReturnDate.Value.Date).TotalDays;
                if(days > 0)
                {
                    // fined
                    var fineAmount = days * 10;
                    return (true, days, fineAmount);
                }
            }
            return (false, 0, 0);
        }
    }
}
