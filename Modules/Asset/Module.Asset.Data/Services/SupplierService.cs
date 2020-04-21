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
    public class SupplierService : ISupplierService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Supplier> _repository;


        public SupplierService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Supplier>();

        }

        public async Task<long> CreateAsync(SupplierCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newEntity = new Supplier
            {
                Name = request.Name,
                Address = request.Address,
                ContactName = request.ContactName,
                ContactEmail = request.ContactEmail,
                ContactPhone = request.ContactPhone,
                IsActive = request.IsActive

            };

            await _repository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return newEntity.Id;
        }


        public async Task<bool> UpdateAsync(SupplierUpdateRequest request, CancellationToken cancellationToken = default)
        {
            Supplier entity = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Supplier not found");

            entity.Name = request.Name;
            entity.Address = request.Address;
            entity.ContactName = request.ContactName;
            entity.ContactEmail = request.ContactEmail;
            entity.ContactPhone = request.ContactPhone;
            entity.IsActive = request.IsActive;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }



        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            Supplier entity = await _repository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Supplier not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<SupplierViewModel> Get(long id, CancellationToken cancellationToken = default)
        {

            var result = await _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new SupplierViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    ContactName = x.ContactName,
                    ContactEmail = x.ContactEmail,
                    ContactPhone = x.ContactPhone,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Supplier not found");

            return result;
        }

        public async Task<PagedCollection<SupplierViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new SupplierViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    ContactName = x.ContactName,
                    ContactEmail = x.ContactEmail,
                    ContactPhone = x.ContactPhone,
                    IsActive = x.IsActive
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<SupplierViewModel>(items, total, pagingOptions);
            return result;
        }


    }
}
