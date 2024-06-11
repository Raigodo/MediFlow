using MediFlow.API.Modules.Journal.Domain.OrdinatoryRecords;
using MediFlow.API.Modules.Journal.Domain.Persons;

namespace MediFlow.API.Modules.Journal.Domain.Notes;

public sealed class Note
{
    public Note()
    {
        NoteId = Guid.NewGuid().ToString();
        CreatedAt = DateTime.UtcNow;
        ModifiedAt = DateTime.UtcNow;
    }

    public string NoteId { get; set; }
    public string CreatorId { get; set; }
    public string TargetPersonId { get; set; }
    public string NoteBody { get; set; }
    public string NoteTag { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }

    public Person TargetPerson { get; set; }
}
