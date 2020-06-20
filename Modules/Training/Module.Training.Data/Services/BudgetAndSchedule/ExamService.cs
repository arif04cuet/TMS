using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class ExamService : IExamService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Exam> _examRepository;

        public ExamService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _examRepository = _unitOfWork.GetRepository<Exam>();
        }

        public async Task<long> CreateAsync(ExamCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _examRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(ExamUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _examRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Exam not found");

            request.Map(entity);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _examRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Exam not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<ExamViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _examRepository.GetAsync(x => x.Id == id, ExamViewModel.Select(), cancellationToken);
            return item;
        }

        public async Task<PagedCollection<ExamViewModel>> ListAsync(long batchScheduleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _examRepository.ListAsync(x => x.BatchScheduleId == batchScheduleId, ExamViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

    }
}
