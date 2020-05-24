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
    public class RoomTypeService : IRoomTypeService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<RoomType> _hostelRepository;

        public RoomTypeService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hostelRepository = _unitOfWork.GetRepository<RoomType>();
        }

        public async Task<long> CreateAsync(RoomTypeCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = new RoomType
            {
                Name = request.Name,
                DesignationId = request.Designation,
                Rent = request.Rent
            };
            await _hostelRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(RoomTypeUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _hostelRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Room type not found");

            entity.Name = request.Name;
            entity.Rent = request.Rent;
            entity.DesignationId = request.Designation;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _hostelRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Room type not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<RoomTypeViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _hostelRepository
                .AsReadOnly()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => new RoomTypeViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Designation = x.DesignationId != null ? IdNameViewModel.Map(x.Designation) : null,
                    Rent = x.Rent
                })
                .FirstOrDefaultAsync();

            if (item == null)
                throw new NotFoundException("Room type not found");

            return item;
        }

        public async Task<PagedCollection<RoomTypeViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var assets = _hostelRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions)
                .ApplyPagination(pagingOptions);

            var results = assets.Select(x => new RoomTypeViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Designation = x.DesignationId != null ? IdNameViewModel.Map(x.Designation) : null,
                Rent = x.Rent
            });

            var total = await assets.Select(x => x.Id).CountAsync(cancellationToken);
            var items = await results.ToListAsync(cancellationToken);

            var result = new PagedCollection<RoomTypeViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
