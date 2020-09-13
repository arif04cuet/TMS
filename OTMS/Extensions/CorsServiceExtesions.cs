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
                    .WithOrigins("https://frontend-tms.softbdltd.com")
                    .WithOrigins("https://api-tms.softbdltd.com")
                    .WithOrigins("https://dashboard-tms.softbdltd.com")
                    .WithOrigins("http://frontend-tms.softbdltd.com")
                    .WithOrigins("http://api-tms.softbdltd.com")
                    .WithOrigins("http://dashboard-tms.softbdltd.com")
                    .WithOrigins("http://localhost:4201")
                    .WithOrigins("http://localhost:4200")
                    .WithOrigins("http://localhost:4300")
                    .WithOrigins("http://localhost:4400")
                    .WithOrigins("http://180.148.214.178")
                    .AllowCredentials();
                });
            });
            return services;
        }
    }
}
