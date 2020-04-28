using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using static Module.Core.Shared.MessageConstants;

namespace Module.Core.Data
{
    public class OfficeService : IOfficeService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Office> _officeRepository;
        private readonly IAppService _appService;

        public OfficeService(
            IUnitOfWork unitOfWork,
            IAppService appService)
        {
            _unitOfWork = unitOfWork;
            _appService = appService;
            _officeRepository = _unitOfWork.GetRepository<Office>();
        }

        public async Task<long> CreateAsync(OfficeCreateRequest request, CancellationToken cancellationToken = default)
        {
            var office = request.ToAddress();
            await _officeRepository.AddAsync(office, cancellationToken);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return office.Id;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var office = await _officeRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (office == null)
                throw new NotFoundException(OFFICE_NOT_FOUND);

            office.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<OfficeViewModel> Get(long id, CancellationToken cancellationToken = default)
        {

            var result = await _officeRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new OfficeViewModel
                {
                    Id = x.Id,
                    OfficeName = x.OfficeName,
                    AddressLine1 = x.AddressLine1,
                    AddressLine2 = x.AddressLine2,
                    Division = IdNameViewModel.Map(x.Division),
                    District = IdNameViewModel.Map(x.District),
                    Upazila = IdNameViewModel.Map(x.Upazila)
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException(OFFICE_NOT_FOUND);

            return result;
        }

        public async Task<PagedCollection<OfficeListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _officeRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new OfficeListViewModel
                {
                    Id = x.Id,
                    OfficeName = x.OfficeName,
                    AddressLine1 = x.AddressLine1,
                    AddressLine2 = x.AddressLine2,
                    Division = IdNameViewModel.Map(x.Division),
                    District = IdNameViewModel.Map(x.District),
                    Upazila = IdNameViewModel.Map(x.Upazila)
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<OfficeListViewModel>(items, total, pagingOptions);
            return result;
        }

        public async Task<bool> UpdateAsync(OfficeUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var office = await _officeRepository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (office == null)
                throw new NotFoundException(OFFICE_NOT_FOUND);

            request.MapTo(office);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

    }
}
