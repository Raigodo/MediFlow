using Mediator;
using MediFlow.API.Modules.Journal.Domain.Models;
using MediFlow.API.Shared.Util.Result;

namespace MediFlow.API.Modules.Journal.UseCases.CreateNote;

public record CreateNoteRequest(string TargetPersonId, string noteContent, string creatorId) : IRequest<Result<Note>>;