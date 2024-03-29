﻿using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Core.Entities;
using Module.Core.Shared;
using Module.Library.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using static Module.Core.Shared.MessageConstants;

namespace Module.Library.Data
{
    public class LibraryService : ILibraryService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<Entities.Library> _libraryRepository;
        public readonly IRepository<Fine> _fineRepository;
        public readonly IRepository<BookIssue> _bookIssueRepository;

        public LibraryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _libraryRepository = _unitOfWork.GetRepository<Entities.Library>();
            _fineRepository = _unitOfWork.GetRepository<Fine>();
            _bookIssueRepository = _unitOfWork.GetRepository<BookIssue>();
        }

        public async Task<long> CreateAsync(LibraryCreateRequest request, CancellationToken ct = default)
        {
            var newItem = new Entities.Library
            {
                Name = request.Name,
                LibrarianId = request.Librarian
            };
            if (request.Address != null)
            {
                newItem.Address = request.Address.ToAddress();
            }
            await _libraryRepository.AddAsync(newItem, ct);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return newItem.Id;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            var item = await _libraryRepository
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            if (item == null)
                throw new NotFoundException(LIBRARY_NOT_FOUND);

            _libraryRepository.Remove(item);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task<PagedCollection<LibraryListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var query = _libraryRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await query
                .Include(x => x.Librarian)
                .ApplyPagination(pagingOptions)
                .Select(x => new LibraryListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Librarian = x.Librarian != null ? new IdNameViewModel
                    {
                        Id = (long)x.LibrarianId,
                        Name = x.Librarian.FullName
                    } : null
                })
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<LibraryListViewModel>(items, total, pagingOptions);
        }

        public async Task<PagedCollection<IdNameViewModel>> ListLibrarianAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var query = _unitOfWork.GetRepository<UserRole>()
                .Where(x => x.RoleId == RoleConstants.Librarian && !x.User.IsDeleted);

            var items = await query
                .ApplyPagination(pagingOptions)
                .Include(x => x.User)
                .Select(x => new IdNameViewModel
                {
                    Id = x.UserId,
                    Name = x.User.FullName
                })
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<IdNameViewModel>(items, total, pagingOptions);
        }

        public async Task<LibraryViewModel> GetAsync(long id)
        {
            var result = await _libraryRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new LibraryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Librarian = x.Librarian != null ? new IdNameViewModel
                    {
                        Id = (long)x.LibrarianId,
                        Name = x.Librarian.FullName
                    } : null,
                    Address = AddressViewModel.Map(x.Address)
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<LibraryCountViewModel> GetCountsAsync()
        {
            var libraryCount = await _libraryRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .CountAsync();

            var bookCategoryCount = await _unitOfWork.GetRepository<BookSubject>()
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .CountAsync();

            var bookCount = await _unitOfWork.GetRepository<BookItem>()
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .CountAsync();

            var result = new LibraryCountViewModel
            {
                LibraryCount = libraryCount,
                BookategoryCount = bookCategoryCount,
                BookCount = bookCount
            };

            return result;
        }


        public async Task<bool> UpdateAsync(LibraryUpdateRequest request, CancellationToken ct = default)
        {
            var item = await _libraryRepository
                .AsQueryable()
                .Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (item == null)
                throw new NotFoundException(LIBRARY_NOT_FOUND);

            item.Name = request.Name;
            item.LibrarianId = request.Librarian;

            if (item.Address != null)
                request.Address.MapTo(item.Address);

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task<PagedCollection<FineListViewModel>> ListFineAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = null)
        {
            var query = _bookIssueRepository
                .Where(x => x.FineId != null && !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await query
                .ApplyPagination(pagingOptions)
                .Include(x => x.Fine)
                .Select(x => new FineListViewModel
                {
                    Id = (long)x.FineId,
                    DueAmount = x.Fine.DueAmount,
                    PaidAmount = x.Fine.TotalAmount - x.Fine.DueAmount,
                    TotalAmount = x.Fine.TotalAmount,
                    PaymentDate = (DateTime)x.Fine.PaymentDate,
                    Member = new IdNameViewModel
                    {
                        Id = (long)x.MemberId,
                        Name = x.Member.FullName
                    },
                    Status = x.Fine.DueAmount <= 0 ? "paid" : "due"
                })
                .ToListAsync(); ;

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<FineListViewModel>(items, total, pagingOptions);
        }

        public async Task<LibraryDashboardViewModel> GetDashboard(CancellationToken cancellationToken = default)
        {
            LibraryDashboardViewModel model = new LibraryDashboardViewModel();

            model.NewItem = await _unitOfWork.GetRepository<BookItem>().Where(x => x.CreatedAt.Value.Date == DateTime.UtcNow.Date && !x.IsDeleted).LongCountAsync();

            // actual return date is over
            model.Pending = await _unitOfWork.GetRepository<BookIssue>().Where(x => x.ReturnDate.Value.Date < DateTime.UtcNow.Date && !x.IsDeleted).LongCountAsync();

            model.ReturnPending = 0;

            model.TodaysIssue = await _unitOfWork.GetRepository<BookIssue>().Where(x => x.IssueDate.Date == DateTime.UtcNow.Date && !x.IsDeleted).LongCountAsync();

            model.TodaysReturn = await _unitOfWork.GetRepository<BookIssue>().Where(x => x.ActualReturnDate.Value.Date == DateTime.UtcNow.Date && !x.IsDeleted).LongCountAsync();

            model.TotalIssued = await _unitOfWork.GetRepository<BookIssue>().Where(x => !x.IsDeleted).LongCountAsync();

            model.TotalItem = await _unitOfWork.GetRepository<BookItem>().Where(x => !x.IsDeleted).LongCountAsync();

            model.TotalMember = await _unitOfWork.GetRepository<LibraryMember>().Where(x => !x.IsDeleted).LongCountAsync();

            return model;
        }
    }
}
