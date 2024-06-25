using Journal.Data.Repositories.Specifications;
using Journal.Domain.Notes;
using Journal.Domain.Notes.Services;
using Microsoft.EntityFrameworkCore;

namespace Journal.Data.Repositories;

public sealed class NoteRepository : GenericRepository<Note>, INoteRepository
{
    public NoteRepository(IJournalDbContext dbContext)
    {
        Set = dbContext.Notes;
    }

    protected override DbSet<Note> Set { get; }
}
