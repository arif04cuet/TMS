using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public interface IServiceRegistrar
    {
        void Register(IServiceCollection services, IConfiguration configuration);

        void Configure(IApplicationBuilder app);
    }
}
