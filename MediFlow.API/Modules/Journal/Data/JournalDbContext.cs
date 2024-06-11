using MediFlow.API.Modules.Journal.Domain.Notes;
using MediFlow.API.Modules.Journal.Domain.OrdinatoryRecords;
using MediFlow.API.Modules.Journal.Domain.Persons;
using Microsoft.EntityFrameworkCore;

namespace MediFlow.API.Modules.Journal.Data;

public class JournalDbContext(DbContextOptions<JournalDbContext> options) : DbContext(options)
{
    public DbSet<Note> Notes { get; set; }
    public DbSet<Person> Persons { get; set; }
    //public DbSet<OrdinatoryRecord> OrdinatoryRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(person =>
        {
            person.HasKey(p => p.Id);

            person.HasMany(p => p.NotesAbout)
                .WithOne(n => n.TargetPerson)
                .HasForeignKey(n => n.TargetPersonId);

            person.HasMany(p => p.OrdinatoryList)
                .WithOne(or => or.TargetPerson)
                .HasForeignKey(or => or.TargetPersonId);
        }); 
    }
}
