using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Module.Core.Filters;
using OTMS.Extensions;
using FluentValidation.AspNetCore;
using Infrastructure;
using Module.Core.Extensions;
using System.IO;
using Module.Core.Shared;
using OTMS.Converter;
using Module.Asset.Data;
using System;

namespace OTMS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataContextOptions(Configuration, GetType().Assembly);
            services.AddDependencies(Configuration);
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));
                //options.Filters.Add(typeof(AuthorizationFilter));
                options.Filters.Add(typeof(ValidationFilter));
                options.Filters.Add(typeof(UnitOfWorkCommitFilter));
            }).ConfigureApiBehaviorOptions(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            })
            .AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblies(ProjectManager.Assemblies);
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new TimeSpanSerializerConverter());
            });

            services.AddCronJob<AssetDepreciationScheduleCronJob>(x =>
            {
                x.CronExpression = @"0 */12 * * *";
                x.TimeZoneInfo = TimeZoneInfo.Local;
            });
            services.AddRazorPages();
            services.AddCronJob<BookReturnScheduleCronJob>(x =>
            {
                // run every day
                x.CronExpression = @"0 0 * * *";
                x.TimeZoneInfo = TimeZoneInfo.Local;
            });

            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ProjectManager.StoragePath = Path.Combine(Directory.GetCurrentDirectory(), MediaConstants.Path);
            ProjectManager.Env = env.EnvironmentName;
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("default");

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFilesService();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseDependencies();
        }
    }
}
