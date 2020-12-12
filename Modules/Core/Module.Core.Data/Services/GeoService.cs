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


namespace Module.Core.Data
{
    public class GeoService : IGeoService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<District> _districtRepository;
        private readonly IRepository<Upazila> _upazilaRepository;


        public GeoService(
            IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;

            _districtRepository = _unitOfWork.GetRepository<District>();
            _upazilaRepository = _unitOfWork.GetRepository<Upazila>();

        }


        public async Task<PagedCollection<GeoViewModel>> ListDistrictAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _districtRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new GeoViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Parent = x.DivisionId != null ? new IdNameViewModel { Id = x.Division.Id, Name = x.Division.Name } : null,
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<GeoViewModel>(items, total, pagingOptions);
            return result;
        }

        public async Task<PagedCollection<GeoViewModel>> ListUpazilaAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _upazilaRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new GeoViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Parent = x.DistrictId != null ? new IdNameViewModel { Id = x.District.Id, Name = x.District.Name } : null,
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<GeoViewModel>(items, total, pagingOptions);
            return result;
        }


    }
}
