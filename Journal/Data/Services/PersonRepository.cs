using Journal.Domain.Persons;
using Journal.Domain.Persons.Services;
using Microsoft.EntityFrameworkCore;

namespace Journal.Data.Services;

public sealed class PersonRepository : IPersonRepository
{
    public PersonRepository(IJournalDbContext dbContext)
    {
        journalDbContext = dbContext;
    }

    private readonly IJournalDbContext journalDbContext;


    public async Task AddAsync(Person person, CancellationToken ct = default)
    {
        journalDbContext.Persons
            .Add(person);
        await journalDbContext.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Person person, CancellationToken ct = default)
    {
        journalDbContext.Persons
            .Remove(person);
        await journalDbContext.SaveChangesAsync(ct);
    }

    public async Task<Person?> GetById(Guid id, CancellationToken ct = default)
    {
        return await journalDbContext.Persons
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(ct);
    }

    public async Task<IEnumerable<Person>> GetAll(CancellationToken ct = default)
    {
        return await journalDbContext.Persons
            .ToListAsync(ct);
    }
}
