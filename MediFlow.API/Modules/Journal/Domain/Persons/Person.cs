using MediFlow.API.Modules.Journal.Domain.Notes;
using MediFlow.API.Modules.Journal.Domain.OrdinatoryRecords;

namespace MediFlow.API.Modules.Journal.Domain.Persons;

public class Person
{
    public string Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<Note> NotesAbout { get; set; }
    public IEnumerable<OrdinatoryRecord> OrdinatoryList { get; set; }
}
