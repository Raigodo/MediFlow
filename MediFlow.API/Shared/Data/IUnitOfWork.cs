namespace MediFlow.API.Shared.Data;

public interface IUnitOfWork
{
    Task<int> CompleteAsync(int id);
}
