using MediFlow.API.Shared.MediateRoutes;

namespace MediFlow.API.Modules.Journal.UseCases.Persons;

public record CreatePerson(Guid PersonId, string Name) : IHttpRequest;