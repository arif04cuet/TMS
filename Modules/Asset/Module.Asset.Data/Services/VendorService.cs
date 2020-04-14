using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class VendorService : IVendorService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Vendor> _vendorRepository;


        public VendorService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _vendorRepository = _unitOfWork.GetRepository<Vendor>();

        }

        public async Task<long> CreateAsync(VendorCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newVendor = new Vendor
            {
                VendorName = request.VendorName,
                VendorEmail = request.VendorEmail,
                StatusId = request.Status,
                AccountManagerName = request.AccountManagerName,
                AccountManagerPhone = request.AccountManagerPhone

            };

            await _vendorRepository.AddAsync(newVendor, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return newVendor.Id;
        }

        public async Task<bool> DeleteAsync(long vendorId, CancellationToken cancellationToken = default)
        {
            Vendor vendor = await _vendorRepository.FirstOrDefaultAsync(x => x.Id == vendorId && !x.IsDeleted, true);

            if (vendor == null)
                throw new NotFoundException("Vendor not found");

            vendor.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<VendorViewModel> Get(long vendorId, CancellationToken cancellationToken = default)
        {

            var result = await _vendorRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new VendorViewModel
                {
                    Id = x.Id,
                    VendorName = x.VendorName,
                    VendorEmail = x.VendorEmail,
                    AccountManagerName = x.AccountManagerName,
                    AccountManagerPhone = x.AccountManagerPhone,

                    Status = x.Status != null ? new IdNameViewModel { Id = x.Status.Id, Name = x.Status.Name } : null
                })
                .FirstOrDefaultAsync(x => x.Id == vendorId);

            if (result == null)
                throw new NotFoundException("Vendor not found");

            return result;
        }

        public async Task<PagedCollection<VendorListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _vendorRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new VendorListViewModel
                {
                    Id = x.Id,
                    VendorName = x.VendorName,
                    VendorEmail = x.VendorEmail,
                    AccountManagerName = x.AccountManagerName,
                    AccountManagerPhone = x.AccountManagerPhone,

                    Status = x.Status != null ? new IdNameViewModel { Id = x.Status.Id, Name = x.Status.Name } : null
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<VendorListViewModel>(items, total, pagingOptions);
            return result;
        }

        public async Task<bool> UpdateAsync(VendorUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var vendor = await _vendorRepository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (vendor == null)
                throw new NotFoundException($"Vendor not found");

            vendor.VendorName = request.VendorName;
            vendor.VendorEmail = request.VendorEmail;
            vendor.AccountManagerName = request.AccountManagerName;
            vendor.AccountManagerPhone = request.AccountManagerPhone;
            vendor.StatusId = request.Status;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

    }
}
