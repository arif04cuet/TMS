using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class BudgetService : IBudgetService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Budget> _budgetRepository;
        private readonly IRepository<BudgetItem> _budgetItemOptionRepository;

        public BudgetService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _budgetRepository = _unitOfWork.GetRepository<Budget>();
            _budgetItemOptionRepository = _unitOfWork.GetRepository<BudgetItem>();
        }

        public async Task<long> CreateAsync(BudgetCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _budgetRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var items = request.Items.Select(x => x.Map());

            await _budgetItemOptionRepository.AddRangeAsync(items, cancellationToken);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(BudgetUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _budgetRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Budget not found");

            request.Map(entity);

            foreach (var item in request.Items)
            {
                if (item.Id.HasValue)
                {
                    // update
                    var dbItem = await _budgetItemOptionRepository
                        .Where(x => x.Id == item.Id.Value && !x.IsDeleted)
                        .FirstOrDefaultAsync(cancellationToken);
                    if (dbItem != null)
                    {
                        item.Map(dbItem);
                    }
                }
                else
                {
                    // new
                    var newItem = item.Map();
                    newItem.BudgetId = entity.Id;
                    await _budgetItemOptionRepository.AddAsync(newItem);
                }
            }

            var requestItemIds = request.Items.Where(x => x.Id.HasValue).Select(x => x.Id.Value);

            var optionToBeDeleted = await _budgetItemOptionRepository
                .Where(x => x.BudgetId == entity.Id && !requestItemIds.Contains(x.Id) && !x.IsDeleted)
                .ToListAsync();

            _budgetItemOptionRepository.RemoveRange(optionToBeDeleted);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _budgetRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Budget not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<BudgetViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _budgetRepository.GetAsync(x => x.Id == id, BudgetViewModel.Select(), cancellationToken);

            return item;
        }

        public async Task<PagedCollection<BudgetViewModel>> ListAsync(long courseScheduleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _budgetRepository.ListAsync(x => x.CourseScheduleId == courseScheduleId, BudgetViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

    }
}
