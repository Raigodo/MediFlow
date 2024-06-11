using Mediator;
using MediFlow.API.Modules.Journal.Domain.Notes;
using MediFlow.API.Shared.Util.Result;

namespace MediFlow.API.Modules.Journal.UseCases.GetNotes;

public record GetNotesQuery(string personId) : IQuery<Result<IEnumerable<Note>>>;
