using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Hackaton_DW_2024.Infrastructure.Auth;

public static class AuthConfiguration
{
    public static void AddJwtAuth(this IServiceCollection services, AuthTokenConfiguration config)
    {
        services.AddSingleton(config);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SigningKey)),
                        ClockSkew = TimeSpan.Zero
                    };
                }
            );
        
    }
}