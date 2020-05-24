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
    public class CourseModuleService : ICourseModuleService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CourseModule> _courseModuleRepository;
    
        public CourseModuleService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _courseModuleRepository = _unitOfWork.GetRepository<CourseModule>();
        }

        public async Task<long> CreateAsync(CourseModuleCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _courseModuleRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(CourseModuleUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _courseModuleRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Course module not found");

            request.Map(entity);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _courseModuleRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Course module not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<CourseModuleViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _courseModuleRepository
                .AsReadOnly()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => CourseModuleViewModel.Map(x))
                .FirstOrDefaultAsync();

            if (item == null)
                throw new NotFoundException("Course module not found");

            return item;
        }

        public async Task<PagedCollection<CourseModuleViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var hostels = _courseModuleRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions)
                .ApplyPagination(pagingOptions);

            var results = hostels.Select(x => CourseModuleViewModel.Map(x));

            var total = await hostels.Select(x => x.Id).CountAsync(cancellationToken);
            var items = await results.ToListAsync(cancellationToken);

            var result = new PagedCollection<CourseModuleViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
