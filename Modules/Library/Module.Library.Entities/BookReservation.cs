using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(BookReservation), Schema = SchemaConstants.Library)]
    public class BookReservation : LibraryEntity
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
