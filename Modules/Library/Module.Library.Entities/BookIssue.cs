using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(BookIssue), Schema = SchemaConstants.Library)]
    public class BookIssue : LibraryEntity
    {
        public long BookId { get; set; }
        public Book Book { get; set; }

        public long? BookItemId { get; set; }
        public BookItem BookItem { get; set; }

        public long? MemberId { get; set; }
        public User Member { get; set; }

        public long? MemberLibraryCardId { get; set; }
        public MemberLibraryCard MemberLibraryCard { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }

        public long? FineId { get; set; }
        public Fine Fine { get; set; }

        public string Note { get; set; }

        public long? ConvertedFromReservationId { get; set; }
        public BookReservation ConvertedFromReservation { get; set; }
    }
}
