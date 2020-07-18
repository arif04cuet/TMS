using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IBudgetService : IScopedService
    {
        Task<long> CreateAsync(BudgetCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(BudgetUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<BudgetViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<BudgetViewModel>> ListAsync(long courseScheduleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<IEnumerable<BudgetRateAutocompleteViewModel>> ListRateAutocompletes(string term);

    }
}
