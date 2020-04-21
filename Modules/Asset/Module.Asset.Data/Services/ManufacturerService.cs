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
    public class ManufacturerService : IManufacturerService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Manufacturer> _repository;


        public ManufacturerService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Manufacturer>();

        }

        public async Task<long> CreateAsync(ManufacturerCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newEntity = new Manufacturer
            {
                Name = request.Name,
                Url = request.Url,
                SupportEmail = request.SupportEmail,
                SupportUrl = request.SupportUrl,
                SupportPhone = request.SupportPhone,
                IsActive = request.IsActive

            };

            await _repository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return newEntity.Id;
        }


        public async Task<bool> UpdateAsync(ManufacturerUpdateRequest request, CancellationToken cancellationToken = default)
        {
            Manufacturer entity = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Manufacturer not found");

            entity.Name = request.Name;
            entity.Url = request.Url;
            entity.SupportEmail = request.SupportEmail;
            entity.SupportPhone = request.SupportPhone;
            entity.SupportUrl = request.SupportUrl;
            entity.IsActive = request.IsActive;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }



        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            Manufacturer entity = await _repository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Manufacturer not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<ManufacturerViewModel> Get(long id, CancellationToken cancellationToken = default)
        {

            var result = await _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new ManufacturerViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Url = x.Url,
                    SupportEmail = x.SupportEmail,
                    SupportUrl = x.SupportUrl,
                    SupportPhone = x.SupportPhone,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Manufacturer not found");

            return result;
        }

        public async Task<PagedCollection<ManufacturerViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new ManufacturerViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Url = x.Url,
                    SupportEmail = x.SupportEmail,
                    SupportUrl = x.SupportUrl,
                    SupportPhone = x.SupportPhone,
                    IsActive = x.IsActive
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<ManufacturerViewModel>(items, total, pagingOptions);
            return result;
        }


    }
}
