using Journal.Domain.Notes;
using Journal.Domain.OrdinatoryRecords;
using Journal.Domain.Persons.Values;

namespace Journal.Domain.Persons;

public class Person
{
    public PersonId Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Note> NotesAbout { get; set; } = [];
    public IEnumerable<OrdinatoryRecord> OrdinatoryList { get; set; } = [];
}
