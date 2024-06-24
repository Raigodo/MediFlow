using Journal.Domain.Persons;

namespace Journal.Domain.Notes;

public sealed class Note
{
    private Note(
        Guid id,
        Guid creatorId,
        Guid targetPersonId,
        string noteBody,
        string noteTag)
    {
        Id = id;
        CreatorId = creatorId;
        TargetPersonId = targetPersonId;
        NoteBody = noteBody;
        NoteTag = noteTag;
    }

    public Guid Id { get; init; }
    public Guid CreatorId { get; init; }
    public Guid TargetPersonId { get; init; }

    public string NoteBody { get; internal set; }
    public string NoteTag { get; internal set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public Person TargetPerson { get; init; }


    internal static Note Create(
        Guid creatorId,
        Guid targetPersonId,
        string noteBody,
        string noteTag)
    {
        var note = new Note(
            id: Guid.NewGuid(),
            creatorId: creatorId,
            targetPersonId: targetPersonId,
            noteBody: noteBody,
            noteTag: noteTag);
        return note;
    }
}
