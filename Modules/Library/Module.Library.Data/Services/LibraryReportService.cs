using Dapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Shared;
using Module.Library.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Library.Data
{
    public class LibraryReportService : ILibraryReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<BookIssue> _bookIssueRepository;
        private readonly IDbConnection _dbConnection;

        public LibraryReportService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _bookIssueRepository = _unitOfWork.GetRepository<BookIssue>();
            _dbConnection = _unitOfWork.GetConnection();
        }

        public async Task<PagedCollection<NewBookListViewModel>> ListNewBookAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = null)
        {
            var previous10Days = DateTime.Now.AddDays(-10);
            var query = _unitOfWork.GetRepository<BookItem>()
                .Where(x => x.StatusId != BookStatusConstants.Lost
                && x.CreatedAt != null
                && x.CreatedAt.Value.Date >= previous10Days
                && !x.IsDeleted);

            var result = await query.Select(x => new NewBookListViewModel
            {
                Author = x.Book.AuthorId != null ? x.Book.Author.Name : "",
                Publisher = x.Book.PublisherId != null ? x.Book.Publisher.Name : "",
                Comment = x.CurrentIssueId != null ? x.CurrentIssue.Note : "",
                Title = x.Book.Title,
                Price = x.PurchagePrice
            })
                .ApplySearch(searchOptions)
                .ApplyPagination(pagingOptions)
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<NewBookListViewModel>(result, total, pagingOptions);
        }

        public async Task<PagedCollection<LostBookListViewModel>> ListLostBookAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = null)
        {
            var query = _unitOfWork.GetRepository<BookItem>()
                .Where(x => x.StatusId == BookStatusConstants.Lost && !x.IsDeleted);

            var result = await query.Select(x => new LostBookListViewModel
            {
                Author = x.Book.AuthorId != null ? x.Book.Author.Name : "",
                Publisher = x.Book.PublisherId != null ? x.Book.Publisher.Name : "",
                RecipientAndDesignation = x.IssuedToId != null ? x.IssuedTo.FullName + (x.IssuedTo.DesignationId != null ? ", " + x.IssuedTo.Designation.Name : "") : "",
                Comment = x.CurrentIssueId != null ? x.CurrentIssue.Note : "",
                Title = x.Book.Title
            })
                .ApplySearch(searchOptions)
                .ApplyPagination(pagingOptions)
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<LostBookListViewModel>(result, total, pagingOptions);
        }

        public async Task<PagedCollection<LibraryAtAGlanceListViewModel>> ListLibraryAtAGlanceAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = null)
        {
            var sql = $@"select b.Id, a.Name Author, p.Name Publisher, b.Title,
                    (select count(*) from [library].[BookItem] bi where bi.BookId = b.Id and bi.StatusId = 3) IssueAmount,
                    stuff(
                        (select ', ' + s.Name from [library].[BookSubject] bs
                        left join [library].[Subject] s on s.Id = bs.SubjectId
                        where bs.BookId = b.Id
                        for xml path('')), 1, 1, ''
                    ) Type
                    from [library].[Book] b
                    left join [library].[Author] a on a.Id = b.AuthorId
                    left join [library].[Publisher] p on p.Id = b.PublisherId
                    order by b.UpdatedAt
                    offset {pagingOptions?.Offset ?? 0} rows fetch next {pagingOptions?.Limit ?? 20} rows only";

            var totalSql = @"select count(*) from [library].[Book]";

            var items = await _dbConnection.QueryAsync<LibraryAtAGlanceListViewModel>(sql);
            int total = await _dbConnection.ExecuteScalarAsync<int>(totalSql);

            var result = new PagedCollection<LibraryAtAGlanceListViewModel>(items, total, pagingOptions);

            return result;
        }

        public async Task<PagedCollection<BookEntryListViewModel>> ListBookEntryAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = null)
        {
            var sql = $@"with cte as (select bi.BookId, cast(bi.CreatedAt as date) EntryDate, count(bi.Id) EntryAmount, max(bi.Id) Id from [library].[BookItem] bi
                group by bi.BookId, cast(bi.CreatedAt as date)
                order by cast(bi.CreatedAt as date) desc
                offset {pagingOptions?.Offset ?? 0} rows fetch next {pagingOptions?.Limit ?? 20} rows only)
                select cte.BookId Id, cte.EntryDate, cte.EntryAmount,
                b.Title, a.Name Author, p.Name Publisher, bi2.PurchagePrice Price from cte
                left join [library].[Book] b on b.Id = cte.BookId
                left join [library].[Author] a on a.Id = b.AuthorId
                left join [library].[Publisher] p on p.Id = b.PublisherId
                left join [library].[BookItem] bi2 on bi2.Id = cte.Id";

            var totalSql = @"with cte as (select bi.BookId bi from [library].[BookItem] bi
                group by bi.BookId, cast(bi.CreatedAt as date))
                        select count(*) from cte";

            var items = await _dbConnection.QueryAsync<BookEntryListViewModel>(sql);
            int total = await _dbConnection.ExecuteScalarAsync<int>(totalSql);

            var result = new PagedCollection<BookEntryListViewModel>(items, total, pagingOptions);

            return result;
        }

        public async Task<PagedCollection<BookIssueListViewModel>> ListIssueAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {

            var query = _bookIssueRepository
                .AsReadOnly()
                .Where(x => x.BookItem.StatusId == BookStatusConstants.Loned && !x.IsDeleted)
                .ApplySearch(searchOptions)
                .OrderByDescending(x => x.IssueDate);

            var result = await query
                .Select(x => new BookIssueListViewModel
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
                })
                .ApplyPagination(pagingOptions)
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<BookIssueListViewModel>(result, total, pagingOptions);
        }

    }
}
