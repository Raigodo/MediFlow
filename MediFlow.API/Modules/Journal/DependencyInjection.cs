using MediFlow.API.Modules.Journal.Endpoints;

namespace MediFlow.API.Modules.Journal;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddJournalModule(this WebApplicationBuilder builder)
    {
        //add services and dependencies
        //builder.Services.AddSingleton<JournalDbContext>();
        return builder;
    }

    public static WebApplication UseJournalModule(this WebApplication app)
    {
        //app.MediateGet...
        var groupBuilder = app.MapGroup("/journal/")
            .WithTags("Journal")
            .RequireAuthorization();

        groupBuilder.MapPost("person{personId}/notes", JournalEndpoints.CreateJournalNote);
        groupBuilder.MapGet("person{personId}/notes", JournalEndpoints.QueryJournalNotes);

        return app;
    }
}
