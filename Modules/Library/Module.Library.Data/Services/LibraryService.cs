using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Core.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
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

        public LibraryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _libraryRepository = _unitOfWork.GetRepository<Entities.Library>();
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
                    Address = x.Address != null ? new AddressViewModel
                    {
                        AddressLine1 = x.Address.AddressLine1,
                        AddressLine2 = x.Address.AddressLine2,
                        ContactName = x.Address.ContactName,
                        District = x.Address.District != null ? new IdNameViewModel
                        {
                            Id = x.Address.District.Id,
                            Name = x.Address.District.Name
                        } : null,
                        Upazila = x.Address.Upazila
                    } : null
                })
                .FirstOrDefaultAsync(x => x.Id == id);

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

    }
}
