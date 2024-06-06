using Microsoft.EntityFrameworkCore;

namespace MediFlow.API.Modules.Journal.Data;

public class JournalDbContext(DbContextOptions options) : DbContext(options)
{

}
