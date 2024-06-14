using MediFlow.API.Modules.Account.Domain.User;
using MediFlow.API.Modules.Journal.Domain.Notes;
using MediFlow.API.Modules.Journal.Domain.Notes.Values;
using MediFlow.API.Modules.Journal.Domain.OrdinatoryRecords;
using MediFlow.API.Modules.Journal.Domain.OrdinatoryRecords.Values;
using MediFlow.API.Modules.Journal.Domain.Persons;
using MediFlow.API.Modules.Journal.Domain.Persons.Values;
using MediFlow.API.Shared.StronglyTypedId;
using Microsoft.EntityFrameworkCore;

namespace MediFlow.API.Modules.Journal.Data;

public class JournalDbContext(DbContextOptions<JournalDbContext> options) : DbContext(options)
{
    public DbSet<Note> Notes { get; set; }
    public DbSet<Person> Persons { get; set; }
    //public DbSet<OrdinatoryRecord> OrdinatoryRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>(note =>
        {
            note.Property(n => n.NoteId)
                .HasConversion<TypedIdConverter<NoteId>>();
            note.Property(n => n.CreatorId)
                .HasConversion<TypedIdConverter<UserId>>();
            note.Property(n => n.TargetPersonId)
                .HasConversion<TypedIdConverter<PersonId>>();
        });


        modelBuilder.Entity<OrdinatoryRecord>()
            .Property(or => or.Id)
            .HasConversion<TypedIdConverter<OrdinatoryRecordId>>();


        modelBuilder.Entity<Person>(person =>
        {
            person.Property(p => p.Id)
                .HasConversion<TypedIdConverter<PersonId>>();

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
