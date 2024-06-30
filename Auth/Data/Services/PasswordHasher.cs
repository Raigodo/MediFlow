using Account.Features.Shared.Contracts;

namespace Account.Data.Services;

public class PasswordHasher : IPasswordHasher
{
    public string Generate(string password) =>
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Veriffy(string password, string hashedPassword) =>
        BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
}
