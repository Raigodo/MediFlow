namespace Account.Features.Shared.Contracts
{
    public interface IPasswordHasher
    {
        string Generate(string password);
        bool Veriffy(string password, string hashedPassword);
    }
}