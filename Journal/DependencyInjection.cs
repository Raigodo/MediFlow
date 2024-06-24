using Journal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Journal;

public static class DependencyInjection
{
    public static IServiceCollection AddJournalModule(this IServiceCollection services)
    {
        services.AddDbContext<IJournalDbContext, JournalDbContext>(options =>
        {
            string basePath = Directory.GetParent(Directory.GetCurrentDirectory())!.FullName;
            string dbFilePath = Path.Combine(basePath, "Journal", "Data", "Database", "Journal.db");
            options.UseSqlite($"DataSource={dbFilePath}");
        });
        return services;
    }
}
