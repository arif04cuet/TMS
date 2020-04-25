using Module.Core.Shared;
using System;

namespace Module.Library.Data
{
    public class BookIssueListViewModel
    {

        public long Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public IdNameViewModel Author { get; set; }
        public IdNameViewModel IssuedTo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }

    }
}
