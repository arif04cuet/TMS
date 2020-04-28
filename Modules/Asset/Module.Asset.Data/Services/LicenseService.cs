using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class LicenseService : ILicenseService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<License> _repository;


        public LicenseService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<License>();

        }

        public async Task<long> CreateAsync(LicenseCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newEntity = new License
            {
                Name = request.Name,
                ProductKey = request.ProductKey,
                Seats = request.Seats,
                OrderNumber = request.OrderNumber,
                LicenseToName = request.LicenseToName,
                LicenseToEmail = request.LicenseToEmail,
                PurchaseDate = request.PurchaseDate,
                PurchaseCost = request.PurchaseCost,
                ExpireDate = request.ExpireDate,
                Note = request.Note,
                CategoryId = request.CategoryId,
                ManufacturerId = request.ManufacturerId,
                IsActive = request.IsActive,
                SupplierId = request.SupplierId,
                LocationId = request.LocationId,
                DepreciationId = request.DepreciationId

            };

            await _repository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return newEntity.Id;
        }


        public async Task<bool> UpdateAsync(LicenseUpdateRequest request, CancellationToken cancellationToken = default)
        {
            License entity = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"License not found");

            entity.Name = request.Name;
            entity.ProductKey = request.ProductKey;
            entity.Seats = request.Seats;
            entity.OrderNumber = request.OrderNumber;
            entity.LicenseToName = request.LicenseToName;
            entity.LicenseToEmail = request.LicenseToEmail;
            entity.PurchaseDate = request.PurchaseDate;
            entity.PurchaseCost = request.PurchaseCost;
            entity.ExpireDate = request.ExpireDate;
            entity.Note = request.Note;
            entity.CategoryId = request.CategoryId;
            entity.ManufacturerId = request.ManufacturerId;
            entity.IsActive = request.IsActive;
            entity.SupplierId = request.SupplierId;
            entity.LocationId = request.LocationId;
            entity.DepreciationId = request.DepreciationId;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }



        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            License entity = await _repository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("License not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<LicenseViewModel> Get(long id, CancellationToken cancellationToken = default)
        {

            var result = await _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new LicenseViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ProductKey = x.ProductKey,
                    Seats = x.Seats,
                    OrderNumber = x.OrderNumber,
                    LicenseToName = x.LicenseToName,
                    LicenseToEmail = x.LicenseToEmail,
                    PurchaseDate = x.PurchaseDate,
                    PurchaseCost = x.PurchaseCost,
                    ExpireDate = x.ExpireDate,
                    Note = x.Note,
                    CategoryId = x.CategoryId,
                    ManufacturerId = x.ManufacturerId,
                    IsActive = x.IsActive,
                    SupplierId = x.SupplierId,
                    LocationId = x.LocationId,
                    DepreciationId = x.DepreciationId
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("License not found");

            return result;
        }

        public async Task<PagedCollection<LicenseViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new LicenseViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ProductKey = x.ProductKey,
                    Seats = x.Seats,
                    OrderNumber = x.OrderNumber,
                    LicenseToName = x.LicenseToName,
                    LicenseToEmail = x.LicenseToEmail,
                    PurchaseDate = x.PurchaseDate,
                    PurchaseCost = x.PurchaseCost,
                    ExpireDate = x.ExpireDate,
                    Note = x.Note,
                    CategoryId = x.CategoryId,
                    ManufacturerId = x.ManufacturerId,
                    IsActive = x.IsActive,
                    SupplierId = x.SupplierId,
                    LocationId = x.LocationId,
                    DepreciationId = x.DepreciationId
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<LicenseViewModel>(items, total, pagingOptions);
            return result;
        }


    }
}
