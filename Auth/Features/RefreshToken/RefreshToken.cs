using Account.Data;
using Account.Features.RefreshToken.Services;
using Account.Features.Shared.Contracts;
using Account.Features.Shared.Services;
using FluentValidation;
using Mediator;

namespace Account.Features.RefreshToken;

public readonly record struct RefrestTokenRequest(
    string refreshToken) : IRequest<RefrestTokenResponse>
{
    public sealed class Validator : AbstractValidator<RefrestTokenRequest>
    {
        public Validator()
        {

        }
    }
}

public sealed record RefrestTokenResponse(
    string acessToken,
    string refreshToken);


public sealed class RefrestTokenRequestHandler(
    JwtProvider jwtProvider,
    IUserRepository users,
    RefreshTokenValidator tokenValidator
    ) : IRequestHandler<RefrestTokenRequest, RefrestTokenResponse>
{
    public async ValueTask<RefrestTokenResponse> Handle(RefrestTokenRequest request, CancellationToken ct)
    {
        var principal = tokenValidator.ValidateAndExtract(request.refreshToken);
        if (principal == null)
            return null;

        var storedUserId = principal
            .FindFirst(JwtClaimNames.UserId)
            ?.Value;
        if (storedUserId == null)
            return null;

        if (!Guid.TryParse(storedUserId, out var userId))
            return null;

        var user = await users.GetUserByIdAsync(userId);
        if (user == null)
            return null;

        var storedRefreshKey = principal
            .FindFirst(JwtClaimNames.RefreshKey)
            ?.Value;
        if (user.RefreshTokenKey.ToString() != storedRefreshKey)
            return null;

        var acessToken = jwtProvider.GenerateAcessToken(user);
        var refreshToken = jwtProvider.GenerateRefreshToken(user);

        user.RegenerateRefreshTokenKey();
        await users.SaveChangesAsync(ct);

        return new RefrestTokenResponse(acessToken, refreshToken);
    }
}
