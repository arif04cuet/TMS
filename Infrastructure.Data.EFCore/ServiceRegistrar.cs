using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data.EFCore
{
    public class ServiceRegistrar : IServiceRegistrar
    {
        public void Configure(IApplicationBuilder app)
        {
            //
        }

        public void Register(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var config = provider.GetService<IConfiguration>();
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
        }
    }
}
