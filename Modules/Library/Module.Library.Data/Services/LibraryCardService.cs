using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Shared;
using Module.Library.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using static Module.Core.Shared.MessageConstants;

namespace Module.Library.Data
{
    public class LibraryCardService : ILibraryCardService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<LibraryCard> _libraryCardRepository;

        public LibraryCardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _libraryCardRepository = _unitOfWork.GetRepository<LibraryCard>();
        }

        public async Task<long> CreateAsync(LibraryCardCreateRequest request, CancellationToken ct = default)
        {
            var newItem = new LibraryCard
            {
                CardNumber = request.CardNumber,
                CardTypeId = request.CardTypeId,
                ExpireDate = request.ExpireDate,
                Fees = request.Fees,
                MaxIssueCount = request.MaxIssueCount
            };
            await _libraryCardRepository.AddAsync(newItem, ct);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return newItem.Id;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            var item = await _libraryCardRepository
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            if (item == null)
                throw new NotFoundException(LIBRARY_CARD_NOT_FOUND);

            _libraryCardRepository.Remove(item);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task<PagedCollection<LibraryCardListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var query = _libraryCardRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new LibraryCardListViewModel
                {
                    CardNumber = x.CardNumber,
                    CardType = x.CardType != null ? new IdNameViewModel
                    {
                        Id = x.CardType.Id,
                        Name = x.CardType.Name
                    } : null,
                    ExpireDate = x.ExpireDate,
                    Fees = x.Fees,
                    MaxIssueCount = x.MaxIssueCount
                })
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<LibraryCardListViewModel>(items, total, pagingOptions);
        }

        public async Task<LibraryCardViewModel> GetAsync(long id)
        {
            var result = await _libraryCardRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new LibraryCardViewModel
                {
                    CardNumber = x.CardNumber,
                    CardType = x.CardType != null ? new IdNameViewModel
                    {
                        Id = x.CardType.Id,
                        Name = x.CardType.Name
                    } : null,
                    ExpireDate = x.ExpireDate,
                    Fees = x.Fees,
                    MaxIssueCount = x.MaxIssueCount
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<bool> UpdateAsync(LibraryCardUpdateRequest request, CancellationToken ct = default)
        {
            var item = await _libraryCardRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (item == null)
                throw new NotFoundException(LIBRARY_CARD_NOT_FOUND);

            item.MaxIssueCount = request.MaxIssueCount;
            item.Fees = request.Fees;
            item.ExpireDate = request.ExpireDate;
            item.CardNumber = request.CardNumber;
            item.CardTypeId = request.CardTypeId;

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

    }
}
