using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Module.Core.Data;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Module.Core.Extensions
{
    public static class JwtExtensions
    {
        static string _secretKey;
        static SymmetricSecurityKey _securityKey;
        static SigningCredentials _signingKey;

        public static void AddJwt(this IServiceCollection services, IConfiguration config)
        {

            var jwtAuthConfig = config.GetSection(nameof(JwtTokenOptions));

            _secretKey = jwtAuthConfig[nameof(JwtTokenOptions.SecretKey)];
            _securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey));
            _signingKey = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);

            services.Configure<JwtTokenOptions>(option =>
            {
                option.Issuer = jwtAuthConfig[nameof(JwtTokenOptions.Issuer)];
                option.Audience = jwtAuthConfig[nameof(JwtTokenOptions.Audience)];
                option.SecretKey = _secretKey;
                option.SigningCredentials = _signingKey;
            });
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(option =>
            {
                option.TokenValidationParameters = CreateTokenParameters(config);
                option.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "Yes");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

        }

        static TokenValidationParameters CreateTokenParameters(IConfiguration config)
        {
            var _jwtAuthConfig = config.GetSection(nameof(JwtTokenOptions));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _jwtAuthConfig[nameof(JwtTokenOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = _jwtAuthConfig[nameof(JwtTokenOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _securityKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };
            return tokenValidationParameters;
        }

    }
}
