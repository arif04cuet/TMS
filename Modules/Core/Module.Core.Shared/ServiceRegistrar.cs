using DinkToPdf;
using DinkToPdf.Contracts;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Core.Shared.Options;

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

            //DinkToPdf
            //services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            // Name Services
            services.AddScoped(typeof(INameService<>), typeof(NameService<>));
            services.AddScoped(typeof(INameCrudService<>), typeof(NameCrudService<>));
        }
    }
}
