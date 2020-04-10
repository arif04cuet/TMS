using Module.Core.Data.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public interface IDesignationService : IIdNameService
    {
        Task<long> CreateAsync(DesignationCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(DesignationUpdateRequest request, CancellationToken cancellationToken = default);
    }
}
