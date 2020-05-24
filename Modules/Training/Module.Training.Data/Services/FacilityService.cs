using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class FacilityService : IFacilityService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Facilities> _facilityRepository;

        public FacilityService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _facilityRepository = _unitOfWork.GetRepository<Facilities>();
        }

        public async Task<long> CreateAsync(FacilityCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = new Facilities
            {
                Name = request.Name,
            };
            await _facilityRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(FacilityUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _facilityRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Facility not found");

            entity.Name = request.Name;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _facilityRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Facility not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<FacilityViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _facilityRepository
                .AsReadOnly()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => new FacilityViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .FirstOrDefaultAsync();

            if (item == null)
                throw new NotFoundException("Facility not found");

            return item;
        }

        public async Task<PagedCollection<FacilityViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var assets = _facilityRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions)
                .ApplyPagination(pagingOptions);

            var results = assets.Select(x => new FacilityViewModel
            {
                Id = x.Id,
                Name = x.Name
            });

            var total = await assets.Select(x => x.Id).CountAsync(cancellationToken);
            var items = await results.ToListAsync(cancellationToken);

            var result = new PagedCollection<FacilityViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
