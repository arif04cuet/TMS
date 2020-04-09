using Infrastructure.Entities;
using Module.Core.Entities;
using System;

namespace Module.Library.Entities
{
    public class BookRequest : BaseEntity
    {
        public long BookId { get; set; }
        public Book Book { get; set; }
        public RequestStatus Status { get; set; }
        public string Note { get; set; }

        public DateTimeOffset RequestDate { get; set; }
        public long RequestById { get; set; }
        public User RequestBy { get; set; }

        public DateTimeOffset? AcceptDate { get; set; }
        public long? AcceptById { get; set; }
        public User AcceptBy { get; set; }

    }
}
