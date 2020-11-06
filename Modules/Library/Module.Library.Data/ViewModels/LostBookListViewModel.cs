using Module.Library.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Library.Data
{
    public class LostBookListViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string RecipientAndDesignation { get; set; }
        public string Comment { get; set; }

        public static Expression<Func<BookItem, LostBookListViewModel>> Select()
        {
            return x => new LostBookListViewModel
            {
                Author = x.Book.AuthorId != null ? x.Book.Author.Name : "",
                Publisher = x.Book.PublisherId != null ? x.Book.Publisher.Name : "",
                RecipientAndDesignation = x.IssuedToId != null ? x.IssuedTo.FullName + (x.IssuedTo.DesignationId != null ? ", " + x.IssuedTo.Designation.Name : "") : "",
                Comment = x.CurrentIssueId != null ? x.CurrentIssue.Note : "",
                Title = x.Book.Title
            };
        }

    }
}
