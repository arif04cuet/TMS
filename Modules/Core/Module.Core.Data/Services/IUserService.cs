using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public interface IUserService : IScopedService
    {
        Task<long> CreateAsync(UserCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long userId, CancellationToken cancellationToken = default);

        Task<UserViewModel> Get(long userId, CancellationToken cancellationToken = default);

        Task<PagedCollection<UserListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(UserUpdateRequest request, CancellationToken cancellationToken = default);

        Task<long> CreateFromFrontendAsync(UserCreateFromFrontendRequest request, CancellationToken cancellationToken = default);
    }
}
