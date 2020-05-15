using Dapper;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class ItemCodeService : IItemCodeService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ItemCode> _repository;
        private readonly IDbConnection _dbConnection;

        public ItemCodeService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<ItemCode>();
            _dbConnection = _unitOfWork.GetConnection();
        }

        public async Task<long> CreateAsync(ItemCodeCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newEntity = request.ToMap();

            await _repository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return newEntity.Id;
        }

        public async Task<bool> UpdateAsync(ItemCodeUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"ItemCode not found");

            entity = request.ToMap(entity);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            ItemCode entity = await _repository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("ItemCode not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<ItemCodeViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var result = await _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new ItemCodeViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    CategoryId = x.CategoryId,
                    Available = x.Available,
                    TotalQuantity = x.TotalQuantity,
                    Category = x.Category,
                    MinQuantity = x.MinQuantity,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("ItemCode not found");

            return result;
        }

        public async Task<PagedCollection<ItemCodeViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new ItemCodeViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    CategoryId = x.CategoryId,
                    Available = x.Available,
                    TotalQuantity = x.TotalQuantity,
                    MinQuantity = x.MinQuantity,
                    IsActive = x.IsActive,
                    Category = x.Category
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<ItemCodeViewModel>(items, total, pagingOptions);
            return result;
        }

        public async Task<PagedCollection<ItemCodeByCategoryViewModel>> ListByCategoryAsync(long categoryId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var sql = $@"with cte
                            as (
                            select c.Id, c.Name, c.ParentId from [asset].[Category] c
                            where c.IsDeleted = 0 and c.ParentId = {categoryId}
                            union all
                            select c1.Id, c1.Name, c1.ParentId
                            from [asset].[Category] c1
                            join cte on cte.Id = c1.ParentId
                            where c1.IsDeleted = 0
                            ) ";

            var itemSql = sql + @"select i.Id, i.Code, i.Name, i.Available, i.MinQuantity,      i.TotalQuantity, cte.Id CategoryId, cte.Name CategoryName from cte
                            join[asset].[ItemCode] i on i.CategoryId = cte.Id ";

            var totalSql = sql + @"select count(i.Id) from cte
                            join [asset].[ItemCode] i on i.CategoryId = cte.Id";

            itemSql += $" order by i.Code ";
            itemSql += pagingOptions.BuildSql();

            var items = await _dbConnection.QueryAsync<ItemCodeByCategoryViewModel>(itemSql);
            var total = await _dbConnection.ExecuteScalarAsync<int>(totalSql);

            var result = new PagedCollection<ItemCodeByCategoryViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
