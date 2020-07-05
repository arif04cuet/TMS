using Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface ITotalMarkService : IScopedService
    {

        Task<long> UpdateAsync(TotalMarkUpdateRequest request);

        Task<IEnumerable<TotalMarkListViewModel>> ListAsync(long batchScheduleId, CancellationToken cancellationToken = default);

    }
}
