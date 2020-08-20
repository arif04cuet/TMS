using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Infrastructure.Data.EFCore
{
    public class ServiceRegistrar : IServiceRegistrar
    {
        public void Configure(IApplicationBuilder app)
        {
            //
        }

        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            var provider = services.BuildServiceProvider();
            var config = provider.GetService<IConfiguration>();
            var logger = provider.GetService<ILoggerFactory>().CreateLogger<ServiceRegistrar>();
            services.Configure<DataContextOptions>(options =>
            {
                options.ConnectionString = config.GetConnectionString("Default");
            });
            services.AddDbContext<IDataContext, DataContext>(ServiceLifetime.Scoped);
            var uowType = typeof(IUnitOfWork);
            services.AddScoped(uowType, serviceProvider =>
            {
                var _dataContext = serviceProvider.GetService<IDataContext>();
                return ActivatorUtilities.CreateInstance(serviceProvider, typeof(UnitOfWork), _dataContext);
            });

            try
            {
                provider = services.BuildServiceProvider();
                var dataContext = provider.GetService<IDataContext>();
                (dataContext as DbContext)?.Database.Migrate();
                logger.LogInformation($"---MIGRATE DONE--- at {DateTime.Now}");
            }
            catch (Exception e)
            {
                logger.LogError($"---MIGRATE ERROR--- at {DateTime.Now}");
                Exception ex = e;
                while(ex != null)
                {
                    logger.LogError(ex.Message);
                    ex = ex.InnerException;
                }
                logger.LogError($"---MIGRATE ERROR END --- at {DateTime.Now}");
            }
        }
    }
}
