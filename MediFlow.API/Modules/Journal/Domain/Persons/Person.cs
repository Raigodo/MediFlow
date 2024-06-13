using MediFlow.API.Modules.Journal.Domain.Notes;
using MediFlow.API.Modules.Journal.Domain.OrdinatoryRecords;
using MediFlow.API.Modules.Journal.Domain.Persons.Values;

namespace MediFlow.API.Modules.Journal.Domain.Persons;

public class Person
{
    public PersonId Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Note> NotesAbout { get; set; } = [];
    public IEnumerable<OrdinatoryRecord> OrdinatoryList { get; set; } = [];
}
