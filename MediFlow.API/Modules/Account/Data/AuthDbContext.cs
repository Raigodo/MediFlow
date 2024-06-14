using MediFlow.API.Modules.Account.Domain.User;
using MediFlow.API.Shared.StronglyTypedId;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediFlow.API.Modules.Account.Data;

public class AuthDbContext(DbContextOptions<AuthDbContext> options) :
    IdentityDbContext<User, IdentityRole<UserId>, UserId>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .Property(u => u.Id)
            .HasConversion<TypedIdConverter<UserId>>();

        builder.Entity<IdentityRole<UserId>>()
            .Property(u => u.Id)
            .HasConversion<TypedIdConverter<UserId>>();

        base.OnModelCreating(builder);
    }
}
