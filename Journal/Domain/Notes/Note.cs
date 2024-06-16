using Journal.Domain.Persons;

namespace Journal.Domain.Notes;

public sealed class Note
{
    public Note()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        ModifiedAt = DateTime.UtcNow;
    }

    public Guid Id { get; set; }
    public Guid CreatorId { get; set; }
    public Guid TargetPersonId { get; set; }

    public string NoteBody { get; set; }
    public string NoteTag { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }

    public Person TargetPerson { get; set; }
}
