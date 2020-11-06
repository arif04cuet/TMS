using Module.Core.Shared;
using Module.Library.Entities;
using System;
using System.Linq.Expressions;

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
        public string Note { get; set; }

        public static Expression<Func<BookIssue, BookIssueListViewModel>> Select()
        {
            return x => new BookIssueListViewModel
            {
                Id = x.Id,
                Isbn = x.Book.Isbn,
                Title = x.Book.Title,
                Author = IdNameViewModel.Map(x.Book.Author),
                IssuedTo = x.Member != null ? new IdNameViewModel
                {
                    Id = x.Member.Id,
                    Name = x.Member.FullName
                } : null,
                ActualReturnDate = x.ActualReturnDate,
                IssueDate = x.IssueDate,
                ReturnDate = x.ReturnDate,
                Note = x.Note
            };
        }

    }
}
