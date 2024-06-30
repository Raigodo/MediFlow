using Account.Features.Shared.Contracts;
using Account.Features.Shared.Services;
using FluentValidation;
using Mediator;

namespace Account.Features.Login;

public readonly record struct LoginRequest(
    string email,
    string password) : IRequest<LoginResponse>
{
    public sealed class Validator : AbstractValidator<LoginRequest>
    {
        public Validator()
        {

        }
    }
}

public sealed record LoginResponse(
    string acessToken,
    string refreshToken);


public sealed class LoginRequestHandler(
    JwtProvider jwtProvider,
    IUserRepository users,
    IPasswordHasher hasher) : IRequestHandler<LoginRequest, LoginResponse>
{
    public async ValueTask<LoginResponse> Handle(LoginRequest request, CancellationToken ct)
    {
        var user = await users.GetUserByEmailAsync(request.email);

        if (user == null)
            return null;

        if (!hasher.Veriffy(request.password, user.PasswordHash))
        {
            return null;
        }

        var acessToken = jwtProvider.GenerateAcessToken(user);
        var refreshToken = jwtProvider.GenerateRefreshToken(user);

        return new LoginResponse(acessToken, refreshToken);
    }
}
