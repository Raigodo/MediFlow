using Account.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Account.Data;

public class AccountDbContext(DbContextOptions<AccountDbContext> options)
    : DbContext(options), IAccountDbContext
{
    public DbSet<User> Users { get; set; }
}
