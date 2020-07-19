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
using System;
using System.IO;
using System.Runtime.InteropServices;

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
            ILogger logger = ServiceFactory.GetService<ILogger<ServiceRegistrar>>();
            IHostingEnvironment hostingEnvironment = ServiceFactory.GetService<IHostingEnvironment>();

            var context = new CustomAssemblyLoadContext();
            logger.LogInformation("DinkToPdf Setup");
            logger.LogInformation($"Content Root Path: {hostingEnvironment.ContentRootPath}");
            var extension = ".dll";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                extension = ".so";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                extension = ".dylib";
            }
            var path = Path.Combine(hostingEnvironment.ContentRootPath, $"libwkhtmltox{extension}");
            logger.LogInformation($"Path: {path}");
            try
            {
                context.LoadUnmanagedLibrary(path);
            }
            catch (Exception ex)
            {
                Exception _ex = ex;
                while (_ex != null)
                {
                    logger.LogError(ex.Message);
                    _ex = _ex.InnerException;
                }
            }

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddTransient<IPdfConverter, DinkToPdfConverter>();

            // Name Services
            services.AddScoped(typeof(INameService<>), typeof(NameService<>));
            services.AddScoped(typeof(INameCrudService<>), typeof(NameCrudService<>));
        }
    }
}
