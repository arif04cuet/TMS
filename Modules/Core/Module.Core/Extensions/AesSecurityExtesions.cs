using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Msi.UtilityKit.Security;

namespace Module.Core.Extensions
{
    public static class AesSecurityExtesions
    {
        public static IServiceCollection AddAesSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            var aesOptions = configuration.GetSection(nameof(AesOptions));
            var key = aesOptions[nameof(AesOptions.Key)];
            var secret = aesOptions[nameof(AesOptions.Secret)];

            services.Configure<AesOptions>(options => {
                options.Key = key;
                options.Secret = secret;
            });

            SecurityUtilities.ConfigureOptions(options =>
            {
                options.Key = key;
                options.Secret = secret;
            });
            return services;
        }
    }
}
