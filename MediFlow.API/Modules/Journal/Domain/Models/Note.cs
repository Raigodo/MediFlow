namespace MediFlow.API.Modules.Journal.Domain.Models;

public sealed class Note
{
    public Note(string creatorId, string targetPersonId, string noteBody)
    {
        CreatorId = creatorId;
        TargetPersonId = targetPersonId;
        NoteBody = noteBody;
        CreatedAt = DateTime.UtcNow;
        ModifiedAt = DateTime.UtcNow;
    }

    public string CreatorId { get; set; }
    public string TargetPersonId { get; set; }
    public string NoteBody { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }

}
