using Account;
using Account.Data;
using Account.Data.Repositories;
using Account.Data.Services;
using Account.Features.Login.Services;
using Account.Features.Shared.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public static class DependencyInjection
{
    public static IServiceCollection AddAuthModule(
        this IServiceCollection services,
        IConfigurationManager configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));

        services.AddDbContext<IAccountDbContext, AccountDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("AccountDb"))
        );

        services.AddSingleton<JwtProvider>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }


    public static IServiceCollection AddJwtAuthentication(
        this IServiceCollection services)
    {
        var jwtOptions = services.BuildServiceProvider()
            .GetRequiredService<IOptions<JwtOptions>>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey))
                });
        return services;
    }


    public static IEndpointRouteBuilder UseAuthModule(this IEndpointRouteBuilder app)
    {
        app.MapAuthEndpoints();
        return app;
    }

}