using Infrastructure.Services;
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
            var config = ServiceFactory.GetService<IConfiguration>();
            var logger = ServiceFactory.GetService<ILoggerFactory>().CreateLogger<ServiceRegistrar>();
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
                var dataContext = ServiceFactory.GetService<IDataContext>();
                (dataContext as DbContext)?.Database.Migrate();
            }
            catch (Exception e)
            {
                logger.LogError($"---MIGRATE ERROR--- at {DateTime.Now}");
                logger.LogError(e.Message);
            }
        }
    }
}
