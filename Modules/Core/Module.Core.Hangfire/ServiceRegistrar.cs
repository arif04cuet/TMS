using Hangfire;
using Infrastructure;
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
            var sp = services.BuildServiceProvider();
            var configuration = sp.GetRequiredService<IConfiguration>();

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
