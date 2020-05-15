﻿using Dapper;
using Infrastructure.Data;
using Module.Asset.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class CheckoutHistoryService : ICheckoutHistoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CheckoutHistory> _historyRepository;
        private readonly IDbConnection _dbConnection;

        public CheckoutHistoryService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _historyRepository = _unitOfWork.GetRepository<CheckoutHistory>();
            _dbConnection = _unitOfWork.GetConnection();
        }

        public async Task<long> CreateAsync(CheckoutHistoryCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _historyRepository.AddAsync(entity);
            var result = await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<PagedCollection<CheckoutHistoryListViewModel>> ListAsync(long? itemId, AssetType? itemType, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var item = itemType.ToString();
            var itemName = itemType == AssetType.User ? "FullName" : "Name";

            var sql = $@"select h.*, item.{itemName} as ItemName,
                            case 
                                when h.TargetType = 1 then t1.Name
                                when h.TargetType = 2 then t2.Name
                                when h.TargetType = 3 then t3.Name
                                when h.TargetType = 4 then t4.Name
                                when h.TargetType = 5 then t5.FullName
                                when h.TargetType = 6 then t6.Name
                            end as TargetName
                        from [asset].[CheckoutHistory] h
                        left join [asset].[{item}] item on item.Id = h.ItemId
                        left join [asset].[Asset] t1 on t1.Id = h.TargetId
                        left join [asset].[Accessory] t2 on t2.Id = h.TargetId
                        left join [asset].[Consumable] t3 on t3.Id = h.TargetId
                        left join [asset].[Component] t4 on t4.Id = h.TargetId
                        left join [core].[User] t5 on t5.Id = h.TargetId
                        left join [asset].[License] t6 on t6.Id = h.TargetId";

            sql += BuildWhere(itemId, itemType);
            sql += $" order by h.IssueDate desc ";
            sql += pagingOptions.BuildSql();

            var items = await _dbConnection.QueryAsync<CheckoutHistoryListViewModel>(sql);

            var totalSql = $@"select count(h.Id) as Total
                            from [asset].[CheckoutHistory] h";

            totalSql += BuildWhere(itemId, itemType);

            var total = await _dbConnection.ExecuteScalarAsync<int>(totalSql);

            var result = new PagedCollection<CheckoutHistoryListViewModel>(items, total, pagingOptions);
            return result;
        }

        private string BuildWhere(long? itemId, AssetType? itemType)
        {
            string where = string.Empty;
            if (itemId.HasValue || itemType.HasValue)
            {
                where += " where";
                var condition = string.Empty;
                if (itemId.HasValue)
                {
                    condition += $" h.ItemId={itemId.Value}";
                }
                if (itemType.HasValue)
                {
                    if (!string.IsNullOrEmpty(condition))
                    {
                        condition += " and";
                    }
                    condition += $" h.ItemType={(int)itemType}";
                }
                where += condition;
            }
            return where;
        }

    }
}
