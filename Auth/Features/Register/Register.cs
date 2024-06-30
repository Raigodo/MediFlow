using Account.Domain.User;
using Account.Features.Shared.Contracts;
using FluentValidation;
using Mediator;

namespace Account.Features.Register;

public readonly record struct RegisterRequest(
    string name,
    string email,
    string password) : IRequest<bool>
{
    public sealed class Validator : AbstractValidator<RegisterRequest>
    {
        public Validator()
        {

        }
    }
}

public sealed class RegisterRequestHandler(
    IUserRepository userRepository,
    IPasswordHasher hasher
    ) : IRequestHandler<RegisterRequest, bool>
{
    public async ValueTask<bool> Handle(RegisterRequest request, CancellationToken ct)
    {
        var user = await userRepository.GetUserByEmailAsync(request.email, ct);

        if (user != null)
            return false;

        user = User.Create(
            request.name,
            hasher.Generate(request.password),
            request.email);

        userRepository.Add(user);

        await userRepository.SaveChangesAsync(ct);

        return true;
    }
}
