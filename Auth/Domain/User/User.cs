namespace Account.Domain.User;

public class User
{
    private User(
        Guid id,
        string name,
        string passwordHash,
        string email)
    {
        Id = id;
        Name = name;
        PasswordHash = passwordHash;
        Email = email;
    }

    public Guid Id { get; init; }
    public string Name { get; private set; }
    public string PasswordHash { get; private set; }
    public string Email { get; private set; }

    public Guid RefreshTokenKey { get; private set; }

    public static User Create(
        Guid id,
        string name,
        string passwordHash,
        string email)
    {
        var user = new User(id, name, passwordHash, email);
        return user;
    }

    public static User Create(
        string name,
        string passwordHash,
        string email)
    {
        var user = new User(Guid.NewGuid(), name, passwordHash, email);
        return user;
    }

    public void RegenerateRefreshTokenKey() => RefreshTokenKey = Guid.NewGuid();
}
