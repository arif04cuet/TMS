﻿using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class CategoryService : ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Category> _categoryRepository;
    
        public CategoryService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = _unitOfWork.GetRepository<Category>();
        }

        public async Task<long> CreateAsync(CategoryCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _categoryRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(CategoryUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _categoryRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Category not found");

            request.Map(entity);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _categoryRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Category not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<CategoryViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _categoryRepository
                .AsReadOnly()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => CategoryViewModel.Map(x))
                .FirstOrDefaultAsync();

            if (item == null)
                throw new NotFoundException("Category not found");

            return item;
        }

        public async Task<PagedCollection<CategoryViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var hostels = _categoryRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions)
                .ApplyPagination(pagingOptions);

            var results = hostels.Select(x => CategoryViewModel.Map(x));

            var total = await hostels.Select(x => x.Id).CountAsync(cancellationToken);
            var items = await results.ToListAsync(cancellationToken);

            var result = new PagedCollection<CategoryViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
