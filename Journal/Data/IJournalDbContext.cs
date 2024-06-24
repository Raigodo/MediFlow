using Journal.Domain.Notes;
using Journal.Domain.OrdinatoryRecords;
using Journal.Domain.Persons;
using Microsoft.EntityFrameworkCore;

namespace Journal.Data;

public interface IJournalDbContext
{
    public DbSet<Note> Notes { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<OrdinatoryRecord> OrdinatoryRecords { get; set; }

    public Task SaveChangesAsync(CancellationToken ct);
}
