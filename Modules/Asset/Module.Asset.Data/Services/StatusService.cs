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
    public class StatusService : IStatusService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<AssetStatus> _repository;


        public StatusService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<AssetStatus>();

        }

        public async Task<long> CreateAsync(StatusCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newEntity = new AssetStatus
            {
                Name = request.Name,
                Type = request.Type,
                Color = request.Color,
                Note = request.Note,
                IsActive = request.IsActive

            };

            await _repository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return newEntity.Id;
        }


        public async Task<bool> UpdateAsync(StatusUpdateRequest request, CancellationToken cancellationToken = default)
        {
            AssetStatus entity = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Status not found");

            entity.Name = request.Name;
            entity.Type = request.Type;
            entity.Color = request.Color;
            entity.Note = request.Note;
            entity.IsActive = request.IsActive;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }



        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            AssetStatus entity = await _repository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Status not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<StatusViewModel> Get(long id, CancellationToken cancellationToken = default)
        {

            var result = await _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new StatusViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Color = x.Color,
                    Note = x.Note,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Status not found");

            return result;
        }

        public async Task<PagedCollection<StatusViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new StatusViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Color = x.Color,
                    Note = x.Note,
                    IsActive = x.IsActive
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<StatusViewModel>(items, total, pagingOptions);
            return result;
        }

        public PagedCollection<object> MasterStatuses(IPagingOptions pagingOptions, ISearchOptions searchOptions = default)
        {
            var list = new List<object>();

            foreach (var item in Enum.GetValues(typeof(MasterStatus)))
            {

                list.Add(new
                {
                    id = (int)item,
                    name = item.ToString()
                });
            }

            var result = new PagedCollection<object>(list, list.Count, pagingOptions);
            return result;
        }
    }
}
