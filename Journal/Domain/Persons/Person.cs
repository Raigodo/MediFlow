using Journal.Domain.Notes;
using Journal.Domain.OrdinatoryRecords;

namespace Journal.Domain.Persons;

public sealed class Person
{
    private Person(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
    public Guid Id { get; init; }
    public string Name { get; set; }

    public IEnumerable<Note> Notes { get; init; } = [];
    public IEnumerable<OrdinatoryRecord> OrdinatoryRecords { get; init; } = [];


    public static Person Create(string name)
    {
        var person = new Person(
            id: Guid.NewGuid(),
            name: name);
        return person;
    }
}
