using Dapper;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Module.Core.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Data;
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
        private readonly IDbConnection _dbConnection;

        public CategoryService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Category>();
            _mediaRepository = _unitOfWork.GetRepository<Media>();
            _dbConnection = _unitOfWork.GetConnection();
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

        public async Task<PagedCollection<CategoryViewModel>> ListAsync(long? parentId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await ListInternalAsync(parentId, pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<PagedCollection<CategoryViewModel>> ListRootAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await ListInternalAsync(null, pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        private async Task<PagedCollection<CategoryViewModel>> ListInternalAsync(long? parentId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var sql = @"with cte
                        as (
                        select c.Id, c.Name, c.ParentId, c.EULA Eula, c.IsSendEmail, c.IsRequireUserConfirmation, c.MediaId, c.IsActive from [asset].[Category] c
                        where c.IsDeleted = 0 and c.ParentId ";

            if (parentId.HasValue)
            {
                sql += $"= {parentId.Value} ";
            }
            else
            {
                sql += "is null ";
            }

            sql += @"union all
                        select c1.Id, c1.Name, c1.ParentId, c1.EULA Eula, c1.IsSendEmail, c1.IsRequireUserConfirmation, c1.MediaId, c1.IsActive
                        from [asset].[Category] c1
                        join cte on cte.Id = c1.ParentId
                        where c1.IsDeleted = 0
                        )";

            var totalWhere = searchOptions.ToSqlSyntax((p, i) => p == "Parent" ? "#c.Name" : "cte.");
            var totalSql = sql + @"select count(cte.Id) from cte";
            if(!string.IsNullOrEmpty(totalWhere))
            {
                totalSql += " left join [asset].[Category] c on c.Id = cte.ParentId ";
                totalSql += $"where {totalWhere} ";
            }

            sql += @"select cte.*, c.Name Parent, c.EULA Eula, c.IsSendEmail, c.IsRequireUserConfirmation, c.MediaId, c.IsActive from cte
            left join[asset].[Category] c on c.Id = cte.ParentId ";

            string where = searchOptions.ToSqlSyntax((prop, index) => {
                if(prop == "Name")
                {
                    return "cte.";
                }
                else if (prop == "Parent")
                {
                    return "#c.Name";
                }
                else
                {
                    return "c.";
                }
            });
            if (!string.IsNullOrEmpty(where))
            {
                sql += $"where {where} ";
            }
            sql += "order by cte.Name ";
            sql += pagingOptions.BuildSql();

            var items = await _dbConnection.QueryAsync<CategoryViewModel>(sql);
            var total = await _dbConnection.ExecuteScalarAsync<int>(totalSql);

            var result = new PagedCollection<CategoryViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
