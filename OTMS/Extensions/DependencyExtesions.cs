using Infrastructure;
using Infrastructure.Extensions;
using Infrastructure.Services;
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
            ServiceFactory.Init(services.BuildServiceProvider());
            services.AddAesSecurity(configuration);
            services.AddCors();
            services.AddJwt(configuration);
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
