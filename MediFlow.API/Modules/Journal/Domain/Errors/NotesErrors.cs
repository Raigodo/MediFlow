using MediFlow.API.Shared.Util.Result;

namespace MediFlow.API.Modules.Journal.Domain.Errors;

public static class NotesErrors
{
    public static Error NotFound(Guid noteId) =>
        new("Journal.Notes.NotFound", $"Specified journal note with the ID = '{noteId}' was not found");
    public static Error AcessDenied(Guid userId, Guid noteID) =>
        new("Journal.Notes.AcessDenied", $"Specified journal note with the ID = '{noteID}' is not acessible for user with Id = '{userId}'");
}
