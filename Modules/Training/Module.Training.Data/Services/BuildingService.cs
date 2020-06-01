using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Entities;
using Module.Core.Shared;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class BuildingService : IBuildingService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Building> _buildingRepository;
        private readonly IRepository<Floor> _floorRepository;

        public BuildingService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _buildingRepository = _unitOfWork.GetRepository<Building>();
            _floorRepository = _unitOfWork.GetRepository<Floor>();
        }

        public async Task<long> CreateAsync(BuildingCreateRequest request, CancellationToken cancellationToken = default)
        {
            var building = new Building
            {
                Name = request.Name,
                HostelId = request.Hostel
            };
            await _buildingRepository.AddAsync(building, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            foreach (var item in request.Floors)
            {
                var floor = new Floor
                {
                    HostelId = request.Hostel,
                    Name = item.Name,
                    BuildingId = building.Id,
                };
                await _floorRepository.AddAsync(floor);
            }
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return building.Id;
        }

        public async Task<bool> UpdateAsync(BuildingUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _buildingRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Building not found");

            entity.Name = request.Name;
            entity.HostelId = request.Hostel;

            foreach (var floor in request.Floors)
            {
                if (floor.Id.HasValue)
                {
                    // update
                    var dbFloor = await _floorRepository
                        .AsQueryable()
                        .FirstOrDefaultAsync(x => x.Id == floor.Id && !x.IsDeleted);
                    if (dbFloor != null)
                    {
                        dbFloor.Name = floor.Name;
                    }
                }
                else
                {
                    // new
                    var newFloor = new Floor
                    {
                        HostelId = request.Hostel,
                        Name = floor.Name,
                        BuildingId = request.Id,
                    };
                    await _floorRepository.AddAsync(newFloor);
                }
            }

            // delete floors
            var requestFloors = request.Floors.Where(x => x.Id.HasValue).Select(x => (long)x.Id);
            var floorsToBeDelete = await _floorRepository
                .Where(x => x.BuildingId == request.Id && x.HostelId == request.Hostel && !requestFloors.Contains(x.Id) && !x.IsDeleted)
                .ToListAsync();
            _floorRepository.RemoveRange(floorsToBeDelete);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _buildingRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Building not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<BuildingViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _buildingRepository
                .AsReadOnly()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => new BuildingViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Hostel = IdNameViewModel.Map(x.Hostel),
                })
                .FirstOrDefaultAsync();

            if (item == null)
                throw new NotFoundException("Building not found");

            item.Floors = await _floorRepository
                .AsReadOnly()
                .Where(x => x.BuildingId == item.Id && x.HostelId == item.Hostel.Id && !x.IsDeleted)
                .Select(x => new IdNameViewModel { Id = x.Id, Name = x.Name })
                .ToListAsync();

            return item;
        }

        public async Task<PagedCollection<BuildingViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var hostels = _buildingRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions)
                .ApplyPagination(pagingOptions);

            var results = hostels.Select(x => new BuildingViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Hostel = IdNameViewModel.Map(x.Hostel)
            });

            var total = await hostels.Select(x => x.Id).CountAsync(cancellationToken);
            var items = await results.ToListAsync(cancellationToken);

            var result = new PagedCollection<BuildingViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
