using MediFlow.API.Shared.Util.Result;

namespace MediFlow.API.Modules.Journal.Domain.Errors;

public static class NotesErrors
{
    public static Error NotFound = new("Journal.Notes.NotFound", "Specified journal note was not found");
    public static Error ForbiddenToEdit = new("Journal.Notes.AcessDenied", "Current user has no permissions to edit specified journal note");
}
