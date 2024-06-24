using Journal.Domain.Notes;
using Journal.Domain.OrdinatoryRecords;
using Journal.Domain.Persons;
using Microsoft.EntityFrameworkCore;

namespace Journal.Data;


public class JournalDbContext(DbContextOptions<JournalDbContext> options) : DbContext(options), IJournalDbContext
{
    public DbSet<Note> Notes { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<OrdinatoryRecord> OrdinatoryRecords { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>()
            .HasKey(n => n.Id);

        modelBuilder.Entity<OrdinatoryRecord>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<Person>(person =>
        {
            person.HasKey(p => p.Id);
            person.HasMany(p => p.Notes)
                .WithOne(n => n.TargetPerson)
                .HasForeignKey(n => n.TargetPersonId);
            person.HasMany(p => p.OrdinatoryRecords)
                .WithOne(o => o.TargetPerson)
                .HasForeignKey(o => o.TargetPersonId);
        });
    }

    async Task IJournalDbContext.SaveChangesAsync(CancellationToken ct)
    {
        await base.SaveChangesAsync(ct);
    }
}
