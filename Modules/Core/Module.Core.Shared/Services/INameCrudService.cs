using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Shared
{
    public interface INameCrudService<T> : INameService<T>
    {
        Task<long> CreateAsync(INameCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(INameUpdateRequest request, CancellationToken cancellationToken = default);
    }
}
