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
    public class RackService : IRackService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<Rack> _rackRepository;

        public RackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _rackRepository = _unitOfWork.GetRepository<Rack>();
        }

        public async Task<long> CreateAsync(RackCreateRequest request, CancellationToken ct = default)
        {
            var newItem = new Rack
            {
                Name = request.Name,
                BuildingName = request.BuildingName,
                FloorNo = request.FloorNo,
                LibraryId = request.Library
            };
            await _rackRepository.AddAsync(newItem, ct);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return newItem.Id;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            var item = await _rackRepository
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            if (item == null)
                throw new NotFoundException(RACK_NOT_FOUND);

            item.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task<PagedCollection<RackListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var query = _rackRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            return await GetRackPagedCollection(query, pagingOptions, searchOptions);
        }

        public async Task<PagedCollection<RackListViewModel>> ListLibraryRacksAsync(long libraryId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var query = _rackRepository
                .AsReadOnly()
                .Where(x => x.LibraryId == libraryId && !x.IsDeleted)
                .ApplySearch(searchOptions);

            return await GetRackPagedCollection(query, pagingOptions, searchOptions);
        }

        public async Task<RackViewModel> GetAsync(long id)
        {
            var result = await _rackRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new RackViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    BuildingName = x.BuildingName,
                    FloorNo = x.FloorNo,
                    Library = x.LibraryId != null ? new IdNameViewModel
                    {
                        Id = x.Library.Id,
                        Name = x.Library.Name
                    } : null
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<bool> UpdateAsync(RackUpdateRequest request, CancellationToken ct = default)
        {
            var item = await _rackRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (item == null)
                throw new NotFoundException(RACK_NOT_FOUND);

            item.Name = request.Name;
            item.BuildingName = request.BuildingName;
            item.FloorNo = request.FloorNo;
            item.LibraryId = request.Library;

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        private async Task<PagedCollection<RackListViewModel>> GetRackPagedCollection(IQueryable<Rack> query, IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new RackListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    FloorNo = x.FloorNo,
                    BuildingName = x.BuildingName,
                    Library = x.LibraryId != null ? new IdNameViewModel
                    {
                        Id = x.Library.Id,
                        Name = x.Library.Name
                    } : null
                })
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<RackListViewModel>(items, total, pagingOptions);
        }

    }
}
