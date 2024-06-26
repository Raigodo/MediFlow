using Journal.Domain.Persons;

namespace Journal.Domain.Notes;

public sealed class Note
{
    private Note(
        Guid id,
        Guid creatorId,
        Guid targetPersonId,
        string noteBody,
        string noteTag,
        DateTime createdAt)
    {
        Id = id;
        CreatorId = creatorId;
        TargetPersonId = targetPersonId;
        NoteBody = noteBody;
        NoteTag = noteTag;
        CreatedAt = createdAt;
    }

    public Guid Id { get; init; }
    public Guid CreatorId { get; init; }
    public Guid TargetPersonId { get; init; }

    public string NoteBody { get; set; }
    public string NoteTag { get; set; }

    public DateTime CreatedAt { get; init; }

    public Person? TargetPerson { get; init; }


    public static Note Create(
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
            noteTag: noteTag,
            createdAt: DateTime.UtcNow);
        return note;
    }
}
