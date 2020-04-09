using Infrastructure;
using Msi.UtilityKit.Pagination;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public interface IUserService : IScopedService
    {
        Task<long> CreateAsync(UserCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long userId, CancellationToken cancellationToken = default);

        Task<UserViewModel> Get(long userId, CancellationToken cancellationToken = default);

        Task<PagedCollection<UserListViewModel>> ListAsync(IPagingOptions pagingOptions, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(UserUpdateRequest request, CancellationToken cancellationToken = default);
    }
}
