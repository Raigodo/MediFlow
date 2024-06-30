using Microsoft.EntityFrameworkCore;

namespace Journal.Data;


public class JournalDbContext(DbContextOptions<JournalDbContext> options) : DbContext(options), IJournalDbContext
{


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    async Task IJournalDbContext.SaveChangesAsync(CancellationToken ct)
    {
        await base.SaveChangesAsync(ct);
    }
}
