using MediFlow.API.Shared.MediateRoutes;

namespace MediFlow.API.Modules.Journal.UseCases.Notes.GetPersonNotes;

public record GetPersonNotes(Guid PersonId) : IHttpRequest;
