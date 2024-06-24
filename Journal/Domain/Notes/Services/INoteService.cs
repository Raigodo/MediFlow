namespace Journal.Domain.Notes.Services;

public interface INoteService
{
    Note Create(Guid creatorId, Guid targetPersonId, string noteBody, string noteTag);
}