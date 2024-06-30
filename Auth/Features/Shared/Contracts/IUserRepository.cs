using Account.Domain.User;

namespace Account.Features.Shared.Contracts;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(Guid id, CancellationToken ct = default);
    Task<User?> GetUserByEmailAsync(string email, CancellationToken ct = default);

    void Remove(User user);
    void Add(User user);
    Task SaveChangesAsync(CancellationToken ct = default);
}
