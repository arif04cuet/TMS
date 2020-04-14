using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
                Address = request.Address?.ToAddress()
            };
            await _libraryRepository.AddAsync(newItem, ct);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return newItem.Id;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            var item = new Entities.Library { Id = id };
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
                .ApplyPagination(pagingOptions)
                .Select(x => new LibraryListViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<LibraryListViewModel>(items, total, pagingOptions);
        }

        public async Task<BookViewModel> GetAsync(long id)
        {
            var result = _libraryRepository
                .AsReadOnly()
                .Select(x => new BookViewModel
                {
                    Id = x.Id
                })
                .FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<bool> UpdateAsync(LibraryUpdateRequest request, CancellationToken ct = default)
        {
            var book = await _libraryRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (book == null)
                throw new NotFoundException(LIBRARY_NOT_FOUND);

            book.Name = request.Name;

            if (book.Address != null)
                request.Address.MapTo(book.Address);

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

    }
}
