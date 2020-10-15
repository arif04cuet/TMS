using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Core.Shared;
using Module.Library.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Collections.Generic;
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
        public readonly IRepository<LibraryCardType> _libraryCardTypeRepository;
        public readonly IMediaService _mediaService;

        public LibraryCardService(IUnitOfWork unitOfWork, IMediaService mediaService)
        {
            _mediaService = mediaService;
            _unitOfWork = unitOfWork;
            _libraryCardRepository = _unitOfWork.GetRepository<LibraryCard>();
            _libraryCardTypeRepository = _unitOfWork.GetRepository<LibraryCardType>();
        }

        public async Task<long> CreateAsync(LibraryCardCreateRequest request, CancellationToken ct = default)
        {
            List<LibraryCard> cards = new List<LibraryCard>();
            for (int i = 0; i < request.NumberOfCopy; i++)
            {
                var card = new LibraryCard
                {
                    Barcode = DateTime.UtcNow.Ticks.ToString(),
                    CardTypeId = request.CardType,
                    //ExpireDate = request.ExpireDate,
                    CardFee = request.CardFee,
                    LateFee = request.LateFee,
                    MaxIssueCount = request.MaxIssueCount,
                    CardStatusId = LibraryCardStatusConstants.Active,
                    LibraryId = request.LibraryId,
                    PhotoId = request.PhotoId
                };
                cards.Add(card);
            }
            await _libraryCardRepository.AddRangeAsync(cards, ct);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            var item = await _libraryCardRepository
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            if (item == null)
                throw new NotFoundException(LIBRARY_CARD_NOT_FOUND);

            item.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task<PagedCollection<LibraryCardListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var query = _libraryCardRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            return await ListCards(query, pagingOptions);
        }

        public async Task<PagedCollection<IdNameViewModel>> ListAssignableAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var query = _libraryCardRepository
                .AsReadOnly()
                .Where(x => x.MemberId == null && !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new IdNameViewModel
                {
                    Id = x.Id,
                    Name = x.Barcode
                })
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<IdNameViewModel>(items, total, pagingOptions);
        }

        public async Task<LibraryCardViewModel> GetAsync(long id)
        {
            var result = await _libraryCardRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new LibraryCardViewModel
                {
                    Id = x.Id,
                    Barcode = x.Barcode,
                    CardType = IdNameViewModel.Map(x.CardType),
                    ExpireDate = x.ExpireDate,
                    CardFee = x.CardFee,
                    LateFee = x.LateFee,
                    MaxIssueCount = x.MaxIssueCount,
                    Status = IdNameViewModel.Map(x.CardStatus),
                    Member = x.MemberId != null ? new IdNameViewModel
                    {
                        Id = x.Member.Id,
                        Name = x.Member.FullName
                    } : null,
                    Photo = _mediaService.GetPhotoUrl(x.Photo)
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
            item.CardFee = request.CardFee;
            item.LateFee = request.LateFee;
            //item.ExpireDate = request.ExpireDate;
            item.CardTypeId = request.CardType;
            item.CardStatusId = request.CardType;
            item.CardStatusId = request.StatusId;
            item.LibraryId = request.LibraryId;

            if (request.PhotoId.HasValue && item.PhotoId != request.PhotoId)
            {
                // photo changed
                long? oldMediaId = item.PhotoId;
                item.PhotoId = request.PhotoId;
                await _mediaService.UseAsync(request.PhotoId.Value);
                _ = _mediaService.DeleteMediaAsync(oldMediaId);
            }

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        private async Task<PagedCollection<LibraryCardListViewModel>> ListCards(IQueryable<LibraryCard> query, IPagingOptions pagingOptions)
        {
            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new LibraryCardListViewModel
                {
                    Id = x.Id,
                    Barcode = x.Barcode,
                    CardType = IdNameViewModel.Map(x.CardType),
                    ExpireDate = x.ExpireDate,
                    CardFee = x.CardFee,
                    LateFee = x.LateFee,
                    MaxIssueCount = x.MaxIssueCount,
                    Member = x.MemberId != null ? new IdNameViewModel
                    {
                        Id = x.Member.Id,
                        Name = x.Member.FullName
                    } : null,
                    Status = IdNameViewModel.Map(x.CardStatus)
                })
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<LibraryCardListViewModel>(items, total, pagingOptions);
        }

    }
}
