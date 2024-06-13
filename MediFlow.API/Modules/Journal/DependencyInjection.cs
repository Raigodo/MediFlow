using MediFlow.API.Modules.Journal.Data;
using MediFlow.API.Modules.Journal.UseCases.CreatePerson;
using MediFlow.API.Modules.Journal.UseCases.Notes.CreateNote;
using MediFlow.API.Modules.Journal.UseCases.Notes.GetNotes;
using MediFlow.API.Shared.MediateRoutes;
using Microsoft.EntityFrameworkCore;

namespace MediFlow.API.Modules.Journal;

public static class DependencyInjection
{
    public static IServiceCollection AddJournalModule(this IServiceCollection services)
    {
        services.AddDbContext<JournalDbContext>(options =>
        {
            options.UseSqlite("DataSource=journal.db");
        });
        return services;
    }

    public static WebApplication UseJournalModule(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("/journal/")
            .WithTags("Journal")
            .RequireAuthorization();

        groupBuilder.MediateGet<GetNotesQuery>("persons/{personId}/notes");
        groupBuilder.MediatePost<CreateNoteRequest>("persons/{personId}/notes");
        groupBuilder.MediatePost<CreatePersonRequest>("persons");

        return app;
    }
}
