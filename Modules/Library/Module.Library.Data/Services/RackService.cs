using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
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
                FloorNo = request.FloorNo
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

            _rackRepository.Remove(item);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

        public async Task<PagedCollection<RackListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var query = _rackRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new RackListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    FloorNo = x.FloorNo,
                    BuildingName = x.BuildingName
                })
                .ToListAsync();

            var total = await query.Select(x => x.Id).CountAsync();
            return new PagedCollection<RackListViewModel>(items, total, pagingOptions);
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
                    FloorNo = x.FloorNo
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

            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result > 0;
        }

    }
}
