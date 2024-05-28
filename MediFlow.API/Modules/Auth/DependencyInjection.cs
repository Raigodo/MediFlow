using MediFlow.API.Modules.Auth.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MediFlow.API.Modules.Auth;

public static class DependencyInjection
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services)
    {
        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);
        services.AddAuthorizationBuilder();

        services.AddDbContext<AuthDbContext>(dbOptions =>
        {
            dbOptions.UseSqlite("DataSource=app.db");
        });

        services.AddIdentityCore<IdentityUser>(opt =>
        {
            opt.Password.RequiredLength = 8;
            opt.User.RequireUniqueEmail = true;
            opt.Password.RequireNonAlphanumeric = false;
            opt.SignIn.RequireConfirmedEmail = false;

        })
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddApiEndpoints();
        return services;
    }

    public static WebApplication UseAuthModule(this WebApplication app)
    {
        //register required stuff
        app.MapIdentityApi<IdentityUser>()
            .WithTags("Auth");

        return app;
    }
}
