using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public static class DataContextExtensions
    {

        public static async Task<PagedCollection<TViewModel>> ListAsync<TEntity, TViewModel>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TViewModel>> selector, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
            where TEntity : BaseEntity
            where TViewModel : class
        {
            query = query.Where(x => !x.IsDeleted);

            if (predicate != null)
                query = query.Where(predicate);

            query = query.ApplySearch(searchOptions);

            var total = await query.Select(x => x.Id).CountAsync(cancellationToken);

            query = query.ApplyPagination(pagingOptions);

            var results = query.Select(selector);
            var items = await results.ToListAsync(cancellationToken);

            var result = new PagedCollection<TViewModel>(items, total, pagingOptions);
            return result;
        }

        public static Task<PagedCollection<TViewModel>> ListAsync<TEntity, TViewModel>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TViewModel>> selector, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
            where TEntity : BaseEntity
            where TViewModel : class
        {
            var result = repository.AsReadOnly().ListAsync(predicate,
                selector,
                pagingOptions,
                searchOptions,
                cancellationToken);

            return result;
        }

        public static Task<PagedCollection<IdNameViewModel>> ListAsync<T>(this IRepository<T> repository, Expression<Func<T, bool>> predicate, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
            where T : IdNameEntity
        {
            return repository.ListAsync(predicate,
                IdNameViewModel.Select<T>(),
                pagingOptions,
                searchOptions,
                cancellationToken);
        }

        public static Task<PagedCollection<TViewModel>> ListAsync<TEntity, TViewModel>(this IUnitOfWork unitOfWork, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TViewModel>> selector, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
           where TEntity : BaseEntity
           where TViewModel : class
        {
            var repository = unitOfWork.GetRepository<TEntity>();

            return repository.ListAsync(predicate,
                selector,
                pagingOptions,
                searchOptions,
                cancellationToken);
        }

        public static Task<PagedCollection<IdNameViewModel>> ListAsync<TEntity>(this IUnitOfWork unitOfWork, Expression<Func<TEntity, bool>> predicate, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
            where TEntity : IdNameEntity
        {
            var repository = unitOfWork.GetRepository<TEntity>();

            return repository.ListAsync(predicate,
                pagingOptions,
                searchOptions,
                cancellationToken);
        }

        public static async Task<TViewModel> GetAsync<TEntity, TViewModel>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TViewModel>> selector, CancellationToken cancellationToken = default)
            where TEntity : BaseEntity
            where TViewModel : class
        {
            query = query.Where(x => !x.IsDeleted);

            if (predicate != null)
                query = query.Where(predicate);

            var results = query.Select(selector);
            var item = await results.FirstOrDefaultAsync(cancellationToken);

            if (item == null)
                throw new NotFoundException("Item not found");

            return item;
        }

        public static Task<TViewModel> GetAsync<TEntity, TViewModel>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TViewModel>> selector, CancellationToken cancellationToken = default)
            where TEntity : BaseEntity
            where TViewModel : class
        {
            return repository.AsReadOnly().GetAsync(predicate,
                selector,
                cancellationToken);
        }

        public static Task<IdNameViewModel> GetAsync<TEntity>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
            where TEntity : IdNameEntity
        {
            return repository.GetAsync(predicate,
                IdNameViewModel.Select<TEntity>(),
                cancellationToken);
        }

        public static Task<TViewModel> GetAsync<TEntity, TViewModel>(this IUnitOfWork unitOfWork, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TViewModel>> selector, CancellationToken cancellationToken = default)
            where TEntity : BaseEntity
            where TViewModel : class
        {
            var repository = unitOfWork.GetRepository<TEntity>();

            return repository.GetAsync(predicate, selector, cancellationToken);
        }

        public static Task<IdNameViewModel> GetAsync<TEntity>(this IUnitOfWork unitOfWork, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
            where TEntity : IdNameEntity
        {
            var repository = unitOfWork.GetRepository<TEntity>();

            return repository.GetAsync(predicate,
                IdNameViewModel.Select<TEntity>(),
                cancellationToken);
        }

        public static async Task<bool> DeleteAsync<TEntity>(this IUnitOfWork unitOfWork, long id, CancellationToken cancellationToken = default)
            where TEntity : BaseEntity
        {
            var repository = unitOfWork.GetRepository<TEntity>();
            var entity = await repository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Item not found");

            entity.IsDeleted = true;
            var result = await unitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        public static async Task<long> CreateAsync<TEntity>(this IUnitOfWork unitOfWork, TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : BaseEntity
        {
            var repository = unitOfWork.GetRepository<TEntity>();
            await repository.AddAsync(entity, cancellationToken);

            var result = await unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

    }
}
