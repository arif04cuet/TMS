using Module.Library.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Library.Data
{
    public class NewBookListViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public double Price { get; set; }
        public string Comment { get; set; }

        public static Expression<Func<BookItem, NewBookListViewModel>> Select()
        {
            return x => new NewBookListViewModel
            {
                Author = x.Book.AuthorId != null ? x.Book.Author.Name : "",
                Publisher = x.Book.PublisherId != null ? x.Book.Publisher.Name : "",
                Comment = x.CurrentIssueId != null ? x.CurrentIssue.Note : "",
                Title = x.Book.Title,
                Price = x.PurchagePrice
            };
        }

    }
}
