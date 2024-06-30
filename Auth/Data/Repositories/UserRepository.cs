using Account.Domain.User;
using Account.Features.Shared.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Account.Data.Repositories;

public sealed class UserRepository(IAccountDbContext dbCtx) : IUserRepository
{
    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken ct = default)
    {
        var user = await dbCtx.Users.FirstOrDefaultAsync(x => x.Email == email);
        return user;
    }

    public async Task<User?> GetUserByIdAsync(Guid id, CancellationToken ct = default)
    {
        var user = await dbCtx.Users.FirstOrDefaultAsync(x => x.Id == id);
        return user;
    }

    public void Add(User user) => dbCtx.Users.Add(user);
    public void Remove(User user) => dbCtx.Users.Remove(user);
    public Task SaveChangesAsync(CancellationToken ct) => dbCtx.SaveChangesAsync(ct);
}
