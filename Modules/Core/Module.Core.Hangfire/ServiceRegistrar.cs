using Hangfire;
using Infrastructure;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Core.Hangfire.Extensions;
using Module.Core.Hangfire.Internal;

namespace Module.Core.Hangfire
{
    public class ServiceRegistrar : IServiceRegistrar
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseHangfire();
            app.InitializeHangfireJobs();
        }

        public void Register(IServiceCollection services, IConfiguration config)
        {
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetService<IConfiguration>();

            services.AddHangfireService(option =>
            {
                option.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection"));
            });

            //overwrite HangfireBaseOptions
            services.PostConfigure<HangfireOptions>(o =>
            {
                o.Dasbhoard.AuthorizationCallback = httpContext =>
                {
                    var user = httpContext.User;
                    return user.Identity.IsAuthenticated && user.IsInRole("admin");
                };
            });
        }
    }
}
