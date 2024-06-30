namespace Journal.Data;

public interface IJournalDbContext
{

    public Task SaveChangesAsync(CancellationToken ct);
}
