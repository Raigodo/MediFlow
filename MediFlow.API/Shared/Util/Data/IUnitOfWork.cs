namespace MediFlow.API.Shared.Util.Data;

public interface IUnitOfWork
{
    Task<int> CompleteAsync(int id);
}
