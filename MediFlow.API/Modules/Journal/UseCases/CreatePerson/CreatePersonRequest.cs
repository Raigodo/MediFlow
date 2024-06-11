using Mediator;
using MediFlow.API.Modules.Journal.Domain.Persons;

namespace MediFlow.API.Modules.Journal.UseCases.CreatePerson;

public record CreatePersonRequest(string Id, string Name) : IRequest<Person>;