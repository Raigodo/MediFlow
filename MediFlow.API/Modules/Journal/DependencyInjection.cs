using MediFlow.API.Modules.Journal.Data;
using MediFlow.API.Modules.Journal.Endpoints;
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

        groupBuilder.MapPost("persons/{personId}/notes", JournalEndpoints.CreateJournalNote);
        groupBuilder.MapGet("persons/{personId}/notes", JournalEndpoints.QueryJournalNotes);
        groupBuilder.MapPost("persons", JournalEndpoints.CreatePerson);

        return app;
    }
}
