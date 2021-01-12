using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface ILicenseService : IScopedService
    {
        Task<long> CreateAsync(LicenseCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(LicenseUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);
        Task<bool> DeleteSeatAsync(long Id, CancellationToken cancellationToken = default);

        Task<LicenseViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<LicenseViewModel> GetDetails(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<LicenseViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<bool> CheckoutAsync(LicenseCheckoutRequest request, CancellationToken cancellationToken = default);
        Task<bool> CheckinAsync(LicenseCheckinRequest request, CancellationToken cancellationToken = default);
    }
}
