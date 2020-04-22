using Module.Core.Shared;
using System;

namespace Module.Library.Data
{
    public class BookItemIssueViewModel
    {
        public long Id { get; set; }
        public IdNameViewModel Book { get; set; }
        public IdNameViewModel BookItem { get; set; }
        public IdNameViewModel Member { get; set; }
        public IdNameViewModel Card { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
