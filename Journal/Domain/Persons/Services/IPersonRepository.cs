namespace Journal.Domain.Persons.Services;

public interface IPersonRepository
{
    Task AddAsync(Person note, CancellationToken ct = default);
    Task DeleteAsync(Person note, CancellationToken ct = default);
    Task<Person?> GetById(Guid id, CancellationToken ct = default);
    Task<IEnumerable<Person>> GetAll(CancellationToken ct = default);

}