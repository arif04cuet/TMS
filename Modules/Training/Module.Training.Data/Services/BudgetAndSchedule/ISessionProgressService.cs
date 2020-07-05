using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface ISessionProgressService : IScopedService
    {

        Task<long> CompleteMultipleAsync(SessionProgressCompleteRequest request, CancellationToken cancellationToken = default);

        Task<byte[]> CompleteMultipleAndGenerateSheetAsync(SessionProgressCompleteRequest request, CancellationToken cancellationToken = default);

        Task<long> CompleteAsync(long routinePeriodId, CancellationToken cancellationToken = default);

        Task<byte[]> CompleteAndGenerateSheetAsync(long batchScheduleId, long routinePeriodId, CancellationToken cancellationToken = default);

        Task<IEnumerable<SessionProgressViewModel>> ListAsync(long batchScheduleId, long? moduleId = null, CancellationToken cancellationToken = default);

    }
}
