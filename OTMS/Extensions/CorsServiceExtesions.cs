using Microsoft.Extensions.DependencyInjection;

namespace OTMS.Extensions
{
    public static class CorsServiceExtesions
    {
        public static IServiceCollection AddCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:4200")
                    .WithOrigins("http://localhost:4300")
                    .AllowCredentials();
                });
            });
            return services;
        }
    }
}
