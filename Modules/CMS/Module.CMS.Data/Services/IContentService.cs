using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.CMS.Data
{
    public interface IContentService : IScopedService
    {
        Task<long> CreateAsync(ContentCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(ContentUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<ContentViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<ContentViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<bool> DeleteImageAsync(long imageId, long? entityId, CancellationToken cancellationToken = default);
        Task<bool> DeleteAttachmentAsync(long attachmentId, long? entityId, CancellationToken cancellationToken = default);

    }
}
