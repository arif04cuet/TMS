using Infrastructure;
using Msi.UtilityKit.Pagination;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface ITotalMarkService : IScopedService
    {

        Task<long> UpdateAsync(TotalMarkUpdateRequest request);

        Task<PagedCollection<TotalMarkListViewModel>> ListAsync(long batchScheduleId, CancellationToken cancellationToken = default);

    }
}
