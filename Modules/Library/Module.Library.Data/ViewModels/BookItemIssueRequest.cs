using Module.Library.Entities;
using System;

namespace Module.Library.Data
{
    public class BookItemIssueRequest
    {
        public long Book { get; set; }
        public long BookItem { get; set; }
        public long Member { get; set; }
        public long Card { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Note { get; set; }

        public BookIssue ToBookIssue()
        {
            return new BookIssue
            {
                BookId = Book,
                BookItemId = BookItem,
                IssueDate = IssueDate,
                MemberId = Member,
                MemberLibraryCardId = Card,
                Note = Note,
                ReturnDate = ReturnDate
            };
        }
    }
}
