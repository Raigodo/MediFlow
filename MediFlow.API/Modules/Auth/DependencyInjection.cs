﻿using MediFlow.API.Modules.Auth.Data;
using MediFlow.API.Modules.Auth.Domain.User;
using Microsoft.AspNetCore.Authentication;
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
            dbOptions.UseSqlite("DataSource=auth.db");
        });

        services.AddIdentityCore<User>(opt =>
        {
            opt.Password.RequiredLength = 8;
            opt.User.RequireUniqueEmail = true;
            opt.Password.RequireNonAlphanumeric = false;
            opt.SignIn.RequireConfirmedEmail = false;

        })
            .AddRoles<IdentityRole<UserId>>()
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddApiEndpoints();
        return services;
    }

    public static WebApplication UseAuthModule(this WebApplication app)
    {
        //register required stuff
        app.MapIdentityApi<User>()
            .WithTags("Auth");

        return app;
    }
}
