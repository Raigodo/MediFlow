using Mediator;
using MediFlow.API.Modules.Journal.Domain.Notes;
using MediFlow.API.Shared.Util.Result;

namespace MediFlow.API.Modules.Journal.UseCases.CreateNote;

public record CreateNoteRequest(string TargetPersonId, string noteContent, string creatorId) : IRequest<ErrorOr<Note>>;