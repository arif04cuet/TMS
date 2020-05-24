using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface ITopicService : IScopedService
    {
        Task<long> CreateAsync(TopicCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(TopicUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<TopicViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<TopicViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
