using Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public interface IProfileService : IScopedService
    {
        //Task<long> CreateAsync(UserCreateRequest request, CancellationToken cancellationToken = default);

        Task<ProfileViewModel> Get(long userId, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(ProfileRequest request, CancellationToken cancellationToken = default);
    }
}
