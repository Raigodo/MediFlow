namespace MediFlow.API.Shared.DataAcess;

public interface IUnitOfWork
{
    Task<int> CompleteAsync(int id);
}
