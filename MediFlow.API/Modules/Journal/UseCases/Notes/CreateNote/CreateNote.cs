using MediFlow.API.Shared.MediateRoutes;

namespace MediFlow.API.Modules.Journal.UseCases.Notes.CreateNote;

public record CreateNote(Guid PersonId, string NoteContent) : IHttpRequest;