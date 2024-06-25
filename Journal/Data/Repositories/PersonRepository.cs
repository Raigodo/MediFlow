using Journal.Data.Repositories.Specifications;
using Journal.Domain.Persons;
using Journal.Domain.Persons.Services;
using Microsoft.EntityFrameworkCore;

namespace Journal.Data.Repositories;

public sealed class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    public PersonRepository(IJournalDbContext dbContext)
    {
        Set = dbContext.Persons;
    }

    protected override DbSet<Person> Set { get; }
}
