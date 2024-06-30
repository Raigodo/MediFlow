using Account.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Account.Data;

public interface IAccountDbContext
{
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
