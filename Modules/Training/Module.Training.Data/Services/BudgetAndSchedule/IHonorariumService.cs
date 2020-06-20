using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IHonorariumService : IScopedService
    {
        Task<long> CreateAsync(HonorariumCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(HonorariumUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<HonorariumViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<HonorariumViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<PagedCollection<HonorariumHeadViewModel>> ListLatestYearHonorariumHeadsAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
