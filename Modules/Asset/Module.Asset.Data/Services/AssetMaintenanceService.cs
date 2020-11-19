using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class AssetMaintenanceService : IAssetMaintenanceService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<AssetMaintenance> _assetMaintenanceRepository;

        public AssetMaintenanceService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _assetMaintenanceRepository = _unitOfWork.GetRepository<AssetMaintenance>();

        }

        public async Task<long> CreateAsync(AssetMaintenanceCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newEntity = request.ToMap();
            await _assetMaintenanceRepository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return newEntity.Id;
        }

        public async Task<bool> UpdateAsync(AssetMaintenanceUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _assetMaintenanceRepository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Asset maintenance not found");

            entity = request.ToMap(entity);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _assetMaintenanceRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Asset maintenance not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<AssetMaintenanceViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var result = await _assetMaintenanceRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new AssetMaintenanceViewModel
                {
                    Id = x.Id,
                    Type = new IdNameViewModel { Id = (long)x.Type, Name = x.Type.ToString() },
                    Asset = new IdNameViewModel { Id = x.Asset.Id, Name = x.Asset.Name },
                    CompletionDate = x.CompletionDate,
                    Cost = x.Cost,
                    IsWarrantyImprovement = x.IsWarrantyImprovement,
                    StartDate = x.StartDate,
                    Supplier = new IdNameViewModel { Id = x.Supplier.Id, Name = x.Supplier.Name },
                    Title = x.Title,
                    Note = x.Note
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Asset maintenance not found");

            return result;
        }

        public async Task<PagedCollection<AssetMaintenanceViewModel>> ListAsync(long assetId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _assetMaintenanceRepository
                .AsReadOnly()
                .Where(x => x.AssetId == assetId && !x.IsDeleted)
                .ApplySearch(searchOptions);

            return await ListAsync(itemsQuery, pagingOptions, searchOptions, cancellationToken); ;
        }

        public async Task<PagedCollection<AssetMaintenanceViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _assetMaintenanceRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            return await ListAsync(itemsQuery, pagingOptions, searchOptions, cancellationToken);
        }

        public PagedCollection<IdNameViewModel> ListTypes(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var items = new List<IdNameViewModel>();
            foreach (var item in Enum.GetValues(typeof(MaintenanceType)))
            {

                items.Add(new IdNameViewModel
                {
                    Id = (int)item,
                    Name = item.ToString()
                });
            }
            var total = items.Count;
            var result = new PagedCollection<IdNameViewModel>(items, total, pagingOptions);
            return result;
        }

        private async Task<PagedCollection<AssetMaintenanceViewModel>> ListAsync(IQueryable<AssetMaintenance> itemsQuery, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new AssetMaintenanceViewModel
                {
                    Id = x.Id,
                    Type = new IdNameViewModel { Id = (long)x.Type, Name = x.Type.ToString() },
                    Asset = new IdNameViewModel { Id = x.Asset.Id, Name = x.Asset.AssetTag + " - " + x.Asset.AssetModel.Name },
                    CompletionDate = x.CompletionDate,
                    Cost = x.Cost,
                    IsWarrantyImprovement = x.IsWarrantyImprovement,
                    StartDate = x.StartDate,
                    Supplier = new IdNameViewModel { Id = x.Supplier.Id, Name = x.Supplier.Name },
                    Title = x.Title,
                    Note = x.Note
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<AssetMaintenanceViewModel>(items, total, pagingOptions);
            return result;
        }
    }
}
