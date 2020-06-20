using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Core.Shared;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class BatchScheduleAllocationService : IBatchScheduleAllocationService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IExcelService _excelService;
        private readonly IRepository<BatchScheduleAllocation> _batchSceduleAllocationRepository;

        public BatchScheduleAllocationService(
            IUnitOfWork unitOfWork,
            IExcelService excelService)
        {
            _unitOfWork = unitOfWork;
            _excelService = excelService;
            _batchSceduleAllocationRepository = _unitOfWork.GetRepository<BatchScheduleAllocation>();
        }

        public async Task<long> CreateAsync(BatchScheduleAllocationCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _batchSceduleAllocationRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(BatchScheduleAllocationUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _batchSceduleAllocationRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Allocation not found");

            request.Map(entity);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> UpdateStatusAsync(BatchScheduleAllocationUpdateStatusRequest request, CancellationToken cancellationToken = default)
        {
            if (request.Ids.Length > 0)
            {
                var batchSchedules = await _batchSceduleAllocationRepository
                    .Where(x => request.Ids.Contains(x.Id) && !x.IsDeleted)
                    .ToListAsync();

                foreach (var batchSchedule in batchSchedules)
                {
                    batchSchedule.Status = (BatchScheduleAllocationStatus)request.Status;
                }
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
                return result > 0;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _batchSceduleAllocationRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Budget not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<BatchScheduleAllocationViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _batchSceduleAllocationRepository.GetAsync(x => x.Id == id, BatchScheduleAllocationViewModel.Select(), cancellationToken);

            return item;
        }

        public async Task<PagedCollection<BatchScheduleAllocationViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _batchSceduleAllocationRepository.ListAsync(BatchScheduleAllocationViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<byte[]> ExportAllocationAsync(ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _batchSceduleAllocationRepository
                .AsQueryable()
                .ApplySearch(searchOptions)
                .Select(BatchScheduleAllocationExcelModel.Select())
                .ToListAsync();

            var bytes = _excelService.Generate(result);
            return bytes;
        }

    }
}
