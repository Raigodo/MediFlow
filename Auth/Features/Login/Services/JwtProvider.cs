using Account.Data;
using Account.Domain.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Account.Features.Login.Services;

public class JwtProvider(IOptions<JwtOptions> options)
{
    private readonly JwtOptions _options = options.Value;

    public string GenerateToken(User user)
    {
        Claim[] claims = [new("userId", user.Id.ToString())];

        var secretKeyBytes = Encoding.UTF8.GetBytes(_options.SecretKey);
        var securityKey = new SymmetricSecurityKey(secretKeyBytes);

        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            signingCredentials: signingCredentials,
            claims: claims,
            issuer: _options.Issuer,
            audience: _options.Audience,
            expires: DateTime.UtcNow.AddMinutes(_options.ExpiresMinutes));

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenValue;
    }
}
