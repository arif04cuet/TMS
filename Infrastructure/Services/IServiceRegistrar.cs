using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public interface IServiceRegistrar
    {
        void Register(IServiceCollection services);

        void Configure(IApplicationBuilder app);
    }
}
