using DinkToPdf;
using DinkToPdf.Contracts;
using Infrastructure;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Module.Core.Shared.Options;
using System.IO;

namespace Module.Core.Shared
{
    public class ServiceRegistrar : IServiceRegistrar
    {
        public void Configure(IApplicationBuilder app)
        {
            //
        }

        public void Register(IServiceCollection services, IConfiguration config)
        {
            // Email
            var emailOptions = config.GetSection(nameof(EmailOptions));
            services.Configure<EmailOptions>(option => emailOptions.Bind(option));

            // new CustomAssemblyLoadContext().LoadUnmanagedLibrary()

            //DinkToPdf
            var serviceProviver = services.BuildServiceProvider();
            ILogger logger = serviceProviver.GetRequiredService<ILogger<ServiceRegistrar>>();
            IHostingEnvironment hostingEnvironment = serviceProviver.GetRequiredService<IHostingEnvironment>();

            var context = new CustomAssemblyLoadContext();
            logger.LogInformation("DinkToPdf Setup");
            logger.LogInformation($"Content Root Path: {hostingEnvironment.ContentRootPath}");
            var path = Path.Combine(hostingEnvironment.ContentRootPath, "libwkhtmltox");
            logger.LogInformation($"Path: {path}");
            context.LoadUnmanagedLibrary(path);

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddTransient<IPdfConverter, DinkToPdfConverter>();

            // Name Services
            services.AddScoped(typeof(INameService<>), typeof(NameService<>));
            services.AddScoped(typeof(INameCrudService<>), typeof(NameCrudService<>));
        }
    }
}
