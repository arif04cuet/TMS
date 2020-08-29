using Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface IAssetDepreciationService : IScopedService
    {
        Task<long> CreateAsync(long assetId, CancellationToken cancellationToken = default);

        Task<long> ApplyAsync(long assetId, CancellationToken cancellationToken = default);

        Task<long> ReviseAsync(long assetId, CancellationToken cancellationToken = default);

    }
}
