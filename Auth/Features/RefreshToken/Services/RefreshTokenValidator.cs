using Account.Data;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Account.Features.RefreshToken.Services;

public sealed class RefreshTokenValidator(IOptions<JwtOptions> jwtOptions)
{
    public ClaimsPrincipal? ValidateAndExtract(string jwtRefreshToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey);

        var ValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };

        try
        {
            var principal = tokenHandler.ValidateToken(jwtRefreshToken, ValidationParameters,
                out SecurityToken validatedToken);
            return principal;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
