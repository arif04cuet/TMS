using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Core.Shared;
using Module.Library.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Library.Data
{
    public class BookReservationService : IBookReservationService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IBookService _bookService;
        public readonly IRepository<BookReservation> _bookReservationRepository;

        public BookReservationService(
            IUnitOfWork unitOfWork,
            IBookService bookService)
        {
            _unitOfWork = unitOfWork;
            _bookService = bookService;
            _bookReservationRepository = _unitOfWork.GetRepository<BookReservation>();
        }
        public async Task<long> CreateAsync(BookReservationCreateRequest request, CancellationToken ct = default)
        {
            var newBookReservation = request.Map();
            newBookReservation.ReservationDate = DateTime.UtcNow;
            newBookReservation.StatusId = ReservationStatusConstants.None;

            var bookItem = await GetBookItem(request.BookItem);

            newBookReservation.BookId = bookItem.BookId;
            bookItem.StatusId = BookStatusConstants.Reserved;
            bookItem.ReservedForId = request.User;

            await _bookReservationRepository.AddAsync(newBookReservation, ct);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return newBookReservation.Id;
        }

        public async Task<PagedCollection<BookReservationListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var result = await _bookReservationRepository.ListAsync(BookReservationListViewModel.Select(), pagingOptions, searchOptions);
            return result;
        }

        public async Task<PagedCollection<IdNameViewModel>> ListAssignableBookItemsAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var result = await _unitOfWork.GetRepository<BookItem>().ListAsync(x => x.StatusId == BookStatusConstants.Available, x => new IdNameViewModel { Id = x.Id, Name = x.Barcode }, pagingOptions, searchOptions);
            return result;
        }

        public async Task<BookReservationListViewModel> GetAsync(long id)
        {
            var result = await _bookReservationRepository.GetAsync(x => x.Id == id, BookReservationListViewModel.Select());
            return result;
        }

        public async Task<bool> UpdateAsync(BookReservationUpdateRequest request, CancellationToken ct = default)
        {
            var reservation = await _bookReservationRepository
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (reservation == null)
                throw new NotFoundException("Reservation not found");

            var bookItem = await GetBookItem(reservation.BookItemId);

            if (reservation.BookItemId != request.BookItem)
            {
                // book item changed
                if (bookItem != null)
                {
                    bookItem.ReservedForId = null;
                    bookItem.StatusId = BookStatusConstants.Available;
                }
            }

            request.Map(reservation);

            if (bookItem != null)
            {
                reservation.BookId = bookItem.BookId;
                bookItem.StatusId = BookStatusConstants.Reserved;
                bookItem.ReservedForId = request.User;
            }

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            var reservation = await _bookReservationRepository
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, false, ct);

            if (reservation == null)
                throw new NotFoundException("Reservation not found");

            reservation.IsDeleted = true;
            await RevertBookItemReservation(reservation.BookItemId);

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task<bool> CancelAsync(long id, CancellationToken ct = default)
        {
            var reservation = await _bookReservationRepository
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, false, ct);

            if (reservation == null)
                throw new NotFoundException("Reservation not found");

            reservation.StatusId = ReservationStatusConstants.Canceled;
            await RevertBookItemReservation(reservation.BookItemId);

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task<bool> IssueAsync(long reservationId, CancellationToken ct = default)
        {
            var reservation = await _bookReservationRepository
                .FirstOrDefaultAsync(x => x.Id == reservationId && !x.IsDeleted, false, ct);

            if (reservation == null)
                throw new NotFoundException("Reservation not found");

            var card = await _unitOfWork.GetRepository<LibraryCard>()
                .Where(x => x.MemberId == reservation.ReservationById && !x.IsDeleted)
                .FirstOrDefaultAsync();

            if (card == null)
                throw new ValidationException("No library card found for this user.");

            var issue = await _bookService.IssueBookItemAsync(new BookItemIssueRequest
            {
                BookItem = (long)reservation.BookItemId,
                Card = card.Id,
                IssueDate = DateTime.UtcNow,
            });

            if (issue > 0)
            {
                reservation.StatusId = ReservationStatusConstants.Completed;
            }

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        private async Task RevertBookItemReservation(long? bookItemId)
        {
            var bookItem = await GetBookItem(bookItemId);
            if (bookItem != null)
            {
                bookItem.StatusId = BookStatusConstants.Available;
                bookItem.ReservedForId = null;
            }
        }

        private async Task<BookItem> GetBookItem(long? bookItemId)
        {
            var bookItem = await _unitOfWork.GetRepository<BookItem>()
                .Where(x => x.Id == bookItemId && !x.IsDeleted)
                .FirstOrDefaultAsync();
            return bookItem;
        }
    }
}
