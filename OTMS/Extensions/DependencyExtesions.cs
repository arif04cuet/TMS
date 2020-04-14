using Infrastructure;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Core.Extensions;

namespace OTMS.Extensions
{
    public static class DependencyExtesions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAesSecurity(configuration);
            services.AddJwt(configuration);
            services.AddCors();
            services.AddModules();

            foreach (var item in ProjectManager.ServiceRegistrars)
            {
                item.Register(services, configuration);
            }

            services.AddSwagger();

            return services;
        }

        public static void UseDependencies(this IApplicationBuilder app)
        {
            app.UseSwaggerService();
        }
    }
}
