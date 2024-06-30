using Account.Features.Login.Services;
using Account.Features.Shared.Contracts;
using FluentValidation;
using Mediator;

namespace Account.Features.Login;

public readonly record struct LoginRequest(
    string email,
    string password) : IRequest<string>
{
    public sealed class Validator : AbstractValidator<LoginRequest>
    {
        public Validator()
        {

        }
    }
}

public sealed class LoginRequestHandler(
    JwtProvider jwtProvider,
    IUserRepository userRepository,
    IPasswordHasher hasher) : IRequestHandler<LoginRequest, string>
{
    public async ValueTask<string> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByEmailAsync(request.email);

        if (user == null)
            return "";

        if (!hasher.Veriffy(request.password, user.PasswordHash))
        {
            return "";
        }

        var generatedToken = jwtProvider.GenerateToken(user);

        return generatedToken;
    }
}
