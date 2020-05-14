﻿using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Module.Core.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class CategoryService : ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Category> _repository;
        private readonly IRepository<Media> _mediaRepository;

        public CategoryService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Category>();
            _mediaRepository = _unitOfWork.GetRepository<Media>();

        }

        public async Task<long> CreateAsync(CategoryCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newEntity = new Category
            {
                Name = request.Name,
                ParentId = request.ParentId,
                EULA = request.Eula,
                IsRequireUserConfirmation = request.IsRequireUserConfirmation,
                IsSendEmail = request.IsSendEmail,
                IsActive = request.IsActive

            };

            if (request.Media.HasValue)
            {
                newEntity.MediaId = request.Media;
                var media = await _mediaRepository
                    .FirstOrDefaultAsync(x => x.Id == request.Media.Value);
                if (media != null)
                {
                    media.IsInUse = true;
                }
            }

            await _repository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return newEntity.Id;
        }

        public async Task<bool> UpdateAsync(CategoryUpdateRequest request, CancellationToken cancellationToken = default)
        {
            Category entity = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Category not found");

            entity.Name = request.Name;
            entity.ParentId = request.ParentId;
            entity.EULA = request.Eula;
            entity.IsRequireUserConfirmation = request.IsRequireUserConfirmation;
            entity.IsSendEmail = request.IsSendEmail;
            entity.IsActive = request.IsActive;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            Category entity = await _repository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Category not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<CategoryViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var result = await _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    ParentId = x.ParentId,
                    Parent = x.ParentId != null ? x.Parent.Name : "",
                    Eula = x.EULA,
                    Name = x.Name,
                    IsRequireUserConfirmation = x.IsRequireUserConfirmation,
                    IsSendEmail = x.IsSendEmail,
                    IsActive = x.IsActive,
                    Photo = x.MediaId.HasValue ? Path.Combine(MediaConstants.Path, x.Media.FileName) : string.Empty
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Category not found");

            return result;
        }

        public async Task<PagedCollection<CategoryViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await ListAsync(null, pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<PagedCollection<CategoryViewModel>> ListRootAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await ListAsync(x => x.ParentId == null, pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        private async Task<PagedCollection<CategoryViewModel>> ListAsync(Expression<Func<Category, bool>> predicate, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            if (predicate != null)
                itemsQuery = itemsQuery.Where(predicate);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    ParentId = x.ParentId,
                    Parent = x.ParentId != null ? x.Parent.Name : "",
                    Eula = x.EULA,
                    Name = x.Name,
                    IsRequireUserConfirmation = x.IsRequireUserConfirmation,
                    IsSendEmail = x.IsSendEmail,
                    IsActive = x.IsActive
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<CategoryViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
