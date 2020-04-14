using Infrastructure.Entities;
using Module.Core.Entities;
using System;

namespace Module.Library.Entities
{
    public class BookReservation : BaseEntity
    {
        public long BookId { get; set; }
        public Book Book { get; set; }

        public long? BookItemId { get; set; }
        public BookItem BookItem { get; set; }

        public long? StatusId { get; set; }
        public ReservationStatus Status { get; set; }
        public string Note { get; set; }

        public DateTime ReservationDate { get; set; }
        public long? ReservationById { get; set; }
        public User ReservationBy { get; set; }

    }
}
