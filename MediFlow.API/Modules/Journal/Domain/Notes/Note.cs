using MediFlow.API.Modules.Auth.Domain.User;
using MediFlow.API.Modules.Journal.Domain.Notes.Values;
using MediFlow.API.Modules.Journal.Domain.Persons;
using MediFlow.API.Modules.Journal.Domain.Persons.Values;

namespace MediFlow.API.Modules.Journal.Domain.Notes;

public sealed class Note
{
    public Note()
    {
        NoteId = new(Guid.NewGuid());
        CreatedAt = DateTime.UtcNow;
        ModifiedAt = DateTime.UtcNow;
    }

    public NoteId NoteId { get; set; }
    public UserId CreatorId { get; set; }
    public PersonId TargetPersonId { get; set; }

    public string NoteBody { get; set; } = string.Empty;
    public string NoteTag { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }

    public Person TargetPerson { get; set; } = default;
}
