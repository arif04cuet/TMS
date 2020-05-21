using Module.Library.Entities;
using System;

namespace Module.Library.Data
{
    public class BookItemIssueRequest
    {
        public long BookItem { get; set; }
        public long Card { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Note { get; set; }
        public bool SendEmail { get; set; }

        public BookIssue ToBookIssue(long bookId, long memberId)
        {
            return new BookIssue
            {
                BookId = bookId,
                BookItemId = BookItem,
                IssueDate = IssueDate,
                MemberId = memberId,
                LibraryCardId = Card,
                Note = Note,
                ReturnDate = ReturnDate
            };
        }
    }
}
