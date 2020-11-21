using Module.Core.Shared;
using Module.Library.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Library.Data
{
    public class BookReservationListViewModel
    {

        public long Id { get; set; }
        public long? BookItemId { get; set; }
        public IdNameViewModel Book { get; set; }
        public IdNameViewModel User { get; set; }
        public IdNameViewModel Status { get; set; }
        public DateTime ReserveDate { get; set; }

        public static Expression<Func<BookReservation, BookReservationListViewModel>> Select()
        {
            return x => new BookReservationListViewModel
            {
                Id = x.Id,
                BookItemId = x.BookItemId,
                Book = new IdNameViewModel { Id = x.BookId, Name = x.Book.Title },
                User = x.ReservationById != null ? new IdNameViewModel { Id = x.ReservationBy.Id, Name = x.ReservationBy.FullName } : null,
                ReserveDate = x.ReservationDate,
                Status = x.StatusId != null ? new IdNameViewModel { Id = x.Status.Id, Name = x.Status.Name } : null
            };
        }

    }
}
