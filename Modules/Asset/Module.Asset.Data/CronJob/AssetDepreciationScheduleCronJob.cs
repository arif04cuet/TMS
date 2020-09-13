using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Module.Core.Shared;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class AssetDepreciationScheduleCronJob : CronJobService
    {
        private readonly IServiceProvider _serviceProvider;

        public AssetDepreciationScheduleCronJob(IScheduleConfig<AssetDepreciationScheduleCronJob> config, IServiceProvider serviceProvider) : base(config.CronExpression, config.TimeZoneInfo)
        {
            _serviceProvider = serviceProvider;
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var assetDepreciationService = scope.ServiceProvider.GetRequiredService<IAssetDepreciationService>();

                var assets = await unitOfWork.GetRepository<Entities.Asset>()
                    .AsReadOnly()
                    .Where(x => !x.HasDepreciated
                    && x.NextDepreciateDate != null
                    && x.NextDepreciateDate.Value.Date <= DateTime.Now.Date
                    && !x.IsDeleted)
                    .Select(x => x.Id)
                    .ToListAsync();

                foreach (var item in assets)
                {
                    await assetDepreciationService.ApplyAsync(item);
                }

                await unitOfWork.CommitAsync();
            }
        }

    }
}
