using Mediator;
using MediFlow.API.Modules.Journal.Domain.Models;
using MediFlow.API.Shared.Util.Result;

namespace MediFlow.API.Modules.Journal.UseCases.GetNotes;

public record GetNotesQuery(string personId) : IQuery<Result<IEnumerable<Note>>>;
