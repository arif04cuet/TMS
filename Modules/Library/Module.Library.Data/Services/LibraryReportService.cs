using Dapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Library.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Collections.Generic;
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

        public Task<PagedCollection<NewBookListViewModel>> ListNewBookAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = null)
        {
            return GetNewBooksQuery().ListAsync(null, NewBookListViewModel.Select(), pagingOptions, searchOptions);
        }

        public Task<PagedCollection<LostBookListViewModel>> ListLostBooksAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = null)
        {
            return GetLostBooksQuery().ListAsync(null, LostBookListViewModel.Select(), pagingOptions, searchOptions);
        }

        public async Task<PagedCollection<LibraryAtAGlanceListViewModel>> ListLibraryAtAGlanceAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = null)
        {
            var sql = GetLibraryAtAGlanceSql(true, pagingOptions, searchOptions);
            var totalSql = @"select count(*) from [library].[Book]";

            var items = await _dbConnection.QueryAsync<LibraryAtAGlanceListViewModel>(sql);
            int total = await _dbConnection.ExecuteScalarAsync<int>(totalSql);

            var result = new PagedCollection<LibraryAtAGlanceListViewModel>(items, total, pagingOptions);

            return result;
        }

        public async Task<PagedCollection<BookEntryListViewModel>> ListBookEntryAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = null)
        {
            var sql = GetBookEntrySql(true, pagingOptions, searchOptions);

            var totalSql = @"with cte as (select bi.BookId bi from [library].[BookItem] bi
                group by bi.BookId, cast(bi.CreatedAt as date))
                        select count(*) from cte";

            var items = await _dbConnection.QueryAsync<BookEntryListViewModel>(sql);
            int total = await _dbConnection.ExecuteScalarAsync<int>(totalSql);

            var result = new PagedCollection<BookEntryListViewModel>(items, total, pagingOptions);

            return result;
        }

        public Task<PagedCollection<BookIssueListViewModel>> ListIssueAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            return GetIssuesQuery().ListAsync(null, BookIssueListViewModel.Select(), pagingOptions, searchOptions);
        }

        public Task<List<NewBookListViewModel>> ExportNewBooksAsync()
        {
            return GetNewBooksQuery()
                .Select(NewBookListViewModel.Select())
                .ToListAsync();
        }

        public Task<List<LostBookListViewModel>> ExportLostBooksAsync()
        {
            return GetLostBooksQuery()
                .Select(LostBookListViewModel.Select())
                .ToListAsync();
        }

        public Task<IEnumerable<LibraryAtAGlanceListViewModel>> ExportLibraryAtAGlanceAsync()
        {
            var sql = GetLibraryAtAGlanceSql();
            return _dbConnection.QueryAsync<LibraryAtAGlanceListViewModel>(sql);
        }

        public Task<IEnumerable<BookEntryListViewModel>> ExportBookEntryAsync()
        {
            var sql = GetBookEntrySql();
            return _dbConnection.QueryAsync<BookEntryListViewModel>(sql);
        }

        public Task<List<BookIssueListViewModel>> ExportIssuesAsync()
        {
            return GetIssuesQuery()
                .Select(BookIssueListViewModel.Select())
                .ToListAsync();
        }

        private IQueryable<BookItem> GetNewBooksQuery()
        {
            var previous10Days = DateTime.Now.AddDays(-10);
            return _unitOfWork.GetRepository<BookItem>()
                .Where(x => x.StatusId != BookStatusConstants.Lost
                && x.CreatedAt != null
                && x.CreatedAt.Value.Date >= previous10Days
                && !x.IsDeleted);
        }

        private IQueryable<BookItem> GetLostBooksQuery()
        {
            return _unitOfWork.GetRepository<BookItem>()
                .Where(x => x.StatusId == BookStatusConstants.Lost && !x.IsDeleted);
        }

        private string GetLibraryAtAGlanceSql(bool withSearchAndPagination = false, IPagingOptions pagingOptions = null, ISearchOptions searchOptions = null)
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
                    left join [library].[Publisher] p on p.Id = b.PublisherId";

            if (withSearchAndPagination)
            {
                sql += $@" order by b.UpdatedAt
                    offset {pagingOptions?.Offset ?? 0} rows fetch next {pagingOptions?.Limit ?? 20} rows only";
            }

            return sql;
        }

        private string GetBookEntrySql(bool withSearchAndPagination = false, IPagingOptions pagingOptions = null, ISearchOptions searchOptions = null)
        {
            var sql = $@"with cte as (select bi.BookId, cast(bi.CreatedAt as date) EntryDate, count(bi.Id) EntryAmount, max(bi.Id) Id from [library].[BookItem] bi
                group by bi.BookId, cast(bi.CreatedAt as date)";
            if (withSearchAndPagination)
            {
                sql += $@" order by cast(bi.CreatedAt as date) desc
                offset {pagingOptions?.Offset ?? 0} rows fetch next {pagingOptions?.Limit ?? 20} rows only";
            }
            sql += $@")
                select cte.BookId Id, cte.EntryDate, cte.EntryAmount,
                b.Title, a.Name Author, p.Name Publisher, bi2.PurchagePrice Price from cte
                left join [library].[Book] b on b.Id = cte.BookId
                left join [library].[Author] a on a.Id = b.AuthorId
                left join [library].[Publisher] p on p.Id = b.PublisherId
                left join [library].[BookItem] bi2 on bi2.Id = cte.Id";
            return sql;
        }

        private IQueryable<BookIssue> GetIssuesQuery()
        {
            return _bookIssueRepository
                .AsReadOnly()
                .Where(x => x.BookItem.StatusId == BookStatusConstants.Loned && !x.IsDeleted)
                .OrderByDescending(x => x.IssueDate);
        }

    }
}
