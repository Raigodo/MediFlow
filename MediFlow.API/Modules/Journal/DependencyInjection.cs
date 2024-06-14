using MediFlow.API.Modules.Journal.Data;
using MediFlow.API.Modules.Journal.UseCases.Notes.CreateNote;
using MediFlow.API.Modules.Journal.UseCases.Notes.DeleteNote;
using MediFlow.API.Modules.Journal.UseCases.Notes.EditNote;
using MediFlow.API.Modules.Journal.UseCases.Notes.GetPersonNotes;
using MediFlow.API.Modules.Journal.UseCases.Persons;
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

        groupBuilder.MediateGet<GetPersonNotes>("persons/{personId}/notes");
        groupBuilder.MediatePost<CreateNote>("persons/{personId}/notes");
        groupBuilder.MediatePut<EditNote>("persons/{personId}/notes/{noteId}");
        groupBuilder.MediateDelete<DeleteNote>("persons/{personId}/notes/{noteId}");
        groupBuilder.MediatePost<CreatePerson>("persons");

        return app;
    }
}
