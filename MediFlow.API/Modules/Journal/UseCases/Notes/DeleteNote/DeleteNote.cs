using MediFlow.API.Shared.MediateRoutes;

namespace MediFlow.API.Modules.Journal.UseCases.Notes.DeleteNote;

public record DeleteNote(Guid PersonId, Guid NoteId) : IHttpRequest;