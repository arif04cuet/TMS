using Module.Library.Entities;

namespace Module.Library.Data
{
    public class BookReservationCreateRequest
    {

        public long BookItem { get; set; }
        public long User { get; set; }

        public BookReservation Map(BookReservation entity = null)
        {
            entity = entity ?? new BookReservation();
            entity.BookItemId = BookItem;
            entity.ReservationById = User;
            return entity;
        }
    }
}
