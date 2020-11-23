using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Msi.UtilityKit.Search;

namespace Module.Library.Entities
{
    [Table(nameof(BookReservation), Schema = SchemaConstants.Library)]
    public class BookReservation : LibraryEntity
    {
        [Searchable]
        public long BookId { get; set; }
        [Searchable]
        public Book Book { get; set; }
        [Searchable]
        public long? BookItemId { get; set; }
        [Searchable]
        public BookItem BookItem { get; set; }

        public long? StatusId { get; set; }
        public ReservationStatus Status { get; set; }
        public string Note { get; set; }

        public DateTime ReservationDate { get; set; }

        public long? ReservationById { get; set; }
        public LibraryMember ReservationBy { get; set; }

    }
}
