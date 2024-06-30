using Account.Data;
using Account.Domain.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Account.Features.Shared.Services;

public class JwtProvider(IOptions<JwtOptions> options)
{
    private readonly JwtOptions _options = options.Value;

    public string GenerateAcessToken(User user)
    {
        Claim[] claims = [new(JwtClaimNames.UserId, user.Id.ToString())];
        return GenerateToken(user, claims);
    }

    public string GenerateRefreshToken(User user)
    {
        Claim[] claims = [
            new(JwtClaimNames.UserId, user.Id.ToString()),
            new(JwtClaimNames.RefreshKey, user.RefreshTokenKey.ToString())
        ];
        return GenerateToken(user, claims);
    }

    private string GenerateToken(User user, Claim[] claimsToInclude)
    {
        var secretKeyBytes = Encoding.UTF8.GetBytes(_options.SecretKey);
        var securityKey = new SymmetricSecurityKey(secretKeyBytes);

        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            signingCredentials: signingCredentials,
            claims: claimsToInclude,
            issuer: _options.Issuer,
            audience: _options.Audience,
            expires: DateTime.UtcNow.AddMinutes(_options.ExpiresMinutes));

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenValue;
    }
}
