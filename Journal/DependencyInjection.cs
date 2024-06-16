using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Journal;

public static class DependencyInjection
{
    public static IServiceCollection AddJournalModule(this IServiceCollection services)
    {
        //services.AddDbContext<JournalDbContext>(options =>
        //{
        //    options.UseSqlite("DataSource=journal.db");
        //});
        return services;
    }

    public static WebApplication UseJournalModule(this WebApplication app)
    {
        //app.UseFastEndpoints();
        return app;
    }
}
