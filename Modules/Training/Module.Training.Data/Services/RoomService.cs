using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Shared;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class RoomService : IRoomService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Room> _roomRepository;
        private readonly IRepository<Bed> _bedRepository;
        private readonly IRepository<RoomFacilities> _roomFacilityRepository;

        public RoomService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _roomRepository = _unitOfWork.GetRepository<Room>();
            _bedRepository = _unitOfWork.GetRepository<Bed>();
            _roomFacilityRepository = _unitOfWork.GetRepository<RoomFacilities>();
        }

        public async Task<long> CreateAsync(RoomCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = new Room
            {
                Name = request.Name,
                BuildingId = request.Building,
                FloorId = request.Floor,
                HostelId = request.Hostel,
                TypeId = request.RoomType
            };
            await _roomRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (request.Beds != null)
            {
                foreach (var item in request.Beds)
                {
                    var bed = new Bed
                    {
                        BuildingId = request.Building,
                        FloorId = request.Floor,
                        HostelId = request.Hostel,
                        RoomId = entity.Id,
                        Name = item.Name
                    };
                    await _bedRepository.AddAsync(bed);
                }
            }

            if (request.Facilities != null)
            {
                foreach (var item in request.Facilities)
                {
                    var facilities = new RoomFacilities
                    {
                        FacilitiesId = (long)item,
                        RoomId = entity.Id
                    };
                    await _roomFacilityRepository.AddAsync(facilities);
                }
            }

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(RoomUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _roomRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Room not found");

            entity.Name = request.Name;
            entity.BuildingId = request.Building;
            entity.FloorId = request.Floor;
            entity.HostelId = request.Hostel;
            entity.TypeId = request.RoomType;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _roomRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Room not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<RoomViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _roomRepository
                .AsReadOnly()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => new RoomViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Building = IdNameViewModel.Map(x.Building),
                    Floor = IdNameViewModel.Map(x.Floor),
                    Hostel = IdNameViewModel.Map(x.Hostel),
                    IsBooked = x.IsBooked,
                    Type = IdNameViewModel.Map(x.Type),
                })
                .FirstOrDefaultAsync();

            if (item == null)
                throw new NotFoundException("Room not found");

            item.Facilities = await _roomFacilityRepository
                .AsReadOnly()
                .Where(x => x.RoomId == item.Id)
                .Select(x => new IdNameViewModel { Id = x.Facilities.Id, Name = x.Facilities.Name })
                .ToListAsync();

            item.Beds = await _bedRepository
                .AsReadOnly()
                .Where(x => x.RoomId == item.Id && x.FloorId == item.Floor.Id && x.BuildingId == item.Building.Id && x.HostelId == item.Hostel.Id && !x.IsDeleted)
                .Select(x => new IdNameViewModel { Id = x.Id, Name = x.Name })
                .ToListAsync();

            return item;
        }

        public async Task<PagedCollection<RoomViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var assets = _roomRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions)
                .ApplyPagination(pagingOptions);

            var results = assets.Select(x => new RoomViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Building = IdNameViewModel.Map(x.Building),
                Floor = IdNameViewModel.Map(x.Floor),
                Hostel = IdNameViewModel.Map(x.Hostel),
                IsBooked = x.IsBooked,
                Type = IdNameViewModel.Map(x.Type)
            });

            var total = await assets.Select(x => x.Id).CountAsync(cancellationToken);
            var items = await results.ToListAsync(cancellationToken);

            var result = new PagedCollection<RoomViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
