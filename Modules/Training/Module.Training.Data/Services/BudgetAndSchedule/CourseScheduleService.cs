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
    public class CourseScheduleService : ICourseScheduleService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBudgetService _budgetService;
        private readonly IRepository<CourseSchedule> _courseScheduleRepository;
        private readonly IRepository<CourseScheduleEligible> _courseScheduleEligibleRepository;
        private readonly IRepository<Budget> _budgetRepository;
        private readonly IRepository<BudgetItem> _budgetItemRepository;

        public CourseScheduleService(
            IUnitOfWork unitOfWork,
            IBudgetService budgetService)
        {
            _unitOfWork = unitOfWork;
            _budgetService = budgetService;
            _courseScheduleRepository = _unitOfWork.GetRepository<CourseSchedule>();
            _courseScheduleEligibleRepository = _unitOfWork.GetRepository<CourseScheduleEligible>();
            _budgetRepository = _unitOfWork.GetRepository<Budget>();
            _budgetItemRepository = _unitOfWork.GetRepository<BudgetItem>();
        }

        public async Task<long> CreateAsync(CourseScheduleCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _courseScheduleRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var eligibles = request.EligibleFor.Select(x => new CourseScheduleEligible
            {
                CourseScheduleId = entity.Id,
                DesignationId = x
            });

            foreach (var budget in request.Budgets)
            {
                var newBudget = budget.Map();
                newBudget.CourseScheduleId = entity.Id;

                await _budgetRepository.AddAsync(newBudget);
                await _unitOfWork.SaveChangesAsync();

                await AddBudgetItems(budget, newBudget.Id);
            }

            await _courseScheduleEligibleRepository.AddRangeAsync(eligibles, cancellationToken);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(CourseScheduleUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _courseScheduleRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Course schedule not found");

            request.Map(entity);

            await _courseScheduleEligibleRepository.UpdateAsync(
                request.EligibleFor,
                x => x.CourseScheduleId == request.Id,
                x => x.DesignationId,
                x => new CourseScheduleEligible
                {
                    CourseScheduleId = entity.Id,
                    DesignationId = x
                },
                ids => x => ids.Contains(x.DesignationId) && x.CourseScheduleId == request.Id);

            // delete budgets
            var requestBudgetIds = request.Budgets
                .Where(x => x.Id.HasValue)
                .Select(x => x.Id.Value);

            var budgetsToBeDeleted = await _budgetRepository
                .Where(x => x.CourseScheduleId == request.Id && !requestBudgetIds.Contains(x.Id) && !x.IsDeleted)
                .ToListAsync();

            _budgetRepository.RemoveRange(budgetsToBeDeleted);

            foreach (var budget in request.Budgets)
            {
                budget.CourseSchedule = request.Id;
                if (budget.Id.HasValue && !budget.ReUsing)
                {
                    // update
                    var dbBudget = await _budgetRepository
                        .FirstOrDefaultAsync(x => x.Id == budget.Id && x.CourseScheduleId == request.Id && !x.IsDeleted);

                    if (dbBudget == null)
                        throw new ValidationException("Budget not found");

                    budget.Map(dbBudget);

                    foreach (var item in budget.Items)
                    {
                        if (item.Id.HasValue)
                        {
                            // update
                            var dbBudgetItem = await _budgetItemRepository
                                .FirstOrDefaultAsync(x => x.Id == item.Id && x.BudgetId == budget.Id && !x.IsDeleted);

                            if (dbBudgetItem == null)
                                throw new ValidationException("Budget item not found");

                            item.Map(dbBudgetItem);
                        }
                        else
                        {
                            // new
                            var newBudgetItem = item.Map();
                            newBudgetItem.BudgetId = budget.Id.Value;
                            await _budgetItemRepository.AddAsync(newBudgetItem);
                        }
                    }

                    // delete budget items
                    var requestBudgetItemIds = budget.Items
                        .Where(x => x.Id.HasValue)
                        .Select(x => x.Id.Value);

                    var budgetItemsToBeDeleted = await _budgetItemRepository
                        .Where(x => x.BudgetId == budget.Id.Value && !requestBudgetItemIds.Contains(x.Id) && !x.IsDeleted)
                        .ToListAsync();

                    _budgetItemRepository.RemoveRange(budgetItemsToBeDeleted);
                }
                else
                {
                    // new
                    var newBudget = budget.Map();

                    await _budgetRepository.AddAsync(newBudget);
                    await _unitOfWork.SaveChangesAsync();

                    await AddBudgetItems(budget, newBudget.Id);
                }

            }

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _courseScheduleRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Course schedule not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<CourseScheduleViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _courseScheduleRepository.GetAsync(x => x.Id == id, CourseScheduleViewModel.Select(), cancellationToken);

            item.EligibleFor = await _courseScheduleEligibleRepository
                .Where(x => x.CourseScheduleId == item.Id && !x.IsDeleted)
                .Select(x => new IdNameViewModel
                {
                    Id = x.DesignationId,
                    Name = x.Designation.Name
                })
                .ToListAsync(cancellationToken);

            item.Budgets = await _unitOfWork.GetRepository<Budget>()
                .Where(x => x.CourseScheduleId == id && !x.IsDeleted)
                .Select(BudgetViewModel.Select())
                .ToListAsync();

            return item;
        }

        public async Task<PagedCollection<CourseScheduleViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _courseScheduleRepository.ListAsync(CourseScheduleViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<PagedCollection<IdNameViewModel>> BudgetListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var query = _courseScheduleRepository.
                AsReadOnly()
                .Where(x => x.Budgets.Select(y => y.Id).Count() > 0)
                .ApplySearch(searchOptions);

            var total = query.Select(x => x.Id).Count();
            var items = await query
                .ApplyPagination(pagingOptions)
                .Select(x => new IdNameViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync(cancellationToken);
            var result = new PagedCollection<IdNameViewModel>(items, total, pagingOptions);

            return result;
        }

        private Task AddBudgetItems(BudgetRequest budget, long budgetId)
        {
            var budgetItems = budget.Items.Select(x =>
            {
                var item = x.Map();
                item.BudgetId = budgetId;
                return item;
            });
            return _budgetItemRepository.AddRangeAsync(budgetItems);
        }

    }
}
