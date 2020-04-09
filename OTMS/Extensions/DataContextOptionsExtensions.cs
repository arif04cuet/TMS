using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OTMS.Extensions
{
    public static class DataContextOptionsExtensions
    {
        public static IServiceCollection AddDataContextOptions(this IServiceCollection services, IConfiguration configuration, Assembly migrationAssembly)
        {
            services.Configure<DataContextOptions>(options =>
            {
                options.ConnectionString = configuration.GetConnectionString("Default");
                options.MigrationsAssembly = migrationAssembly.FullName;
            });
            return services;
        }
    }
}
