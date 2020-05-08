using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class AssetService : IAssetService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Entities.Asset> _assetRepository;

        public AssetService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _assetRepository = _unitOfWork.GetRepository<Entities.Asset>();

        }

        public async Task<long> CreateAsync(AssetCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newEntity = request.ToMap();

            await _assetRepository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return newEntity.Id;
        }

        public async Task<bool> UpdateAsync(AssetUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _assetRepository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Asset not found");

            entity = request.ToMap(entity);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _assetRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Asset not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<AssetViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var result = await _assetRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new AssetViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PurchaseDate = x.PurchaseDate,
                    PurchaseCost = x.PurchaseCost,
                    Note = x.Note,
                    Supplier = x.SupplierId != null ? new IdNameViewModel { Id = x.Supplier.Id, Name = x.Supplier.Name } : null,
                    Location = x.LocationId != null ? new IdNameViewModel { Id = x.Location.Id, Name = x.Location.OfficeName } : null,
                    AssetModel = new IdNameViewModel { Id = x.AssetModel.Id, Name = x.AssetModel.Name },
                    IsRequestable = x.IsRequestable,
                    ItemNo = x.ItemNo,
                    OrderNo = x.OrderNo,
                    Status = new IdNameViewModel { Id = x.Status.Id, Name = x.Status.Name },
                    Warranty = x.Warranty
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Asset not found");

            return result;
        }
        //public async Task<LicenseViewModel> GetDetails(long id, CancellationToken cancellationToken = default)
        //{

        //    var result = await _accessoryRepository
        //        .AsReadOnly()
        //        .Where(x => !x.IsDeleted)
        //        .Where(x => x.IsActive == true)
        //        .Include(x => x.Manufacturer)
        //        .Include(x => x.Supplier)
        //        .Include(x => x.Location)
        //        .Select(x => new LicenseViewModel
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //            ProductKey = x.ProductKey,
        //            Seats = x.Seats,
        //            OrderNumber = x.OrderNumber,
        //            LicenseToName = x.LicenseToName,
        //            LicenseToEmail = x.LicenseToEmail,
        //            PurchaseDate = x.PurchaseDate,
        //            PurchaseCost = x.PurchaseCost,
        //            ExpireDate = x.ExpireDate,
        //            Note = x.Note,
        //            CategoryId = x.CategoryId,
        //            Category = x.Category,
        //            ManufacturerId = x.ManufacturerId,
        //            Manufacturer = x.Manufacturer,
        //            IsActive = x.IsActive,
        //            SupplierId = x.SupplierId,
        //            Supplier = x.Supplier,
        //            LocationId = x.LocationId,
        //            DepreciationId = x.DepreciationId,
        //            Depreciation = x.Depreciation,
        //            SeatList = x.LicenseSeats

        //        })
        //        .FirstOrDefaultAsync(x => x.Id == id);

        //    if (result == null)
        //        throw new NotFoundException("License not found");

        //    return result;
        //}
        public async Task<PagedCollection<AssetViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _assetRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new AssetViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PurchaseDate = x.PurchaseDate,
                    PurchaseCost = x.PurchaseCost,
                    Note = x.Note,
                    Supplier = x.SupplierId != null ? new IdNameViewModel { Id = x.Supplier.Id, Name = x.Supplier.Name } : null,
                    Location = x.LocationId != null ? new IdNameViewModel { Id = x.Location.Id, Name = x.Location.OfficeName } : null,
                    AssetModel = new IdNameViewModel { Id = x.AssetModel.Id, Name = x.AssetModel.Name },
                    IsRequestable = x.IsRequestable,
                    ItemNo = x.ItemNo,
                    OrderNo = x.OrderNo,
                    Status = new IdNameViewModel { Id = x.Status.Id, Name = x.Status.Name },
                    Warranty = x.Warranty
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<AssetViewModel>(items, total, pagingOptions);
            return result;
        }
        //public async Task<long> CreateSeats(License license, CancellationToken ct = default)
        //{
        //    List<LicenseSeat> items = new List<LicenseSeat>();
        //    for (int i = 0; i < license.Seats; i++)
        //    {
        //        items.Add(new LicenseSeat
        //        {
        //            Name = "Seat " + i,
        //            LicenseId = license.Id
        //        });
        //    }
        //    await _seatRepository.AddRangeAsync(items, ct);
        //    var result = await _unitOfWork.SaveChangesAsync(ct);
        //    return result;
        //}
    }
}
