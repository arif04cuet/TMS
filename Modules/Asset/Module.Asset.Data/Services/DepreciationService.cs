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
    public class DepreciationService : IDepreciationService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Depreciation> _repository;


        public DepreciationService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Depreciation>();

        }

        public async Task<long> CreateAsync(DepreciationCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newEntity = new Depreciation
            {
                Name = request.Name,
                Term = request.Term,
                IsActive = request.IsActive

            };

            await _repository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return newEntity.Id;
        }


        public async Task<bool> UpdateAsync(DepreciationUpdateRequest request, CancellationToken cancellationToken = default)
        {
            Depreciation entity = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Depreciation not found");

            entity.Name = request.Name;
            entity.Term = request.Term;
            entity.IsActive = request.IsActive;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }



        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            Depreciation entity = await _repository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Depreciation not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<DepreciationViewModel> Get(long id, CancellationToken cancellationToken = default)
        {

            var result = await _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new DepreciationViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Term = x.Term,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Depreciation not found");

            return result;
        }

        public async Task<PagedCollection<DepreciationViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new DepreciationViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Term = x.Term,
                    IsActive = x.IsActive
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<DepreciationViewModel>(items, total, pagingOptions);
            return result;
        }


    }
}
