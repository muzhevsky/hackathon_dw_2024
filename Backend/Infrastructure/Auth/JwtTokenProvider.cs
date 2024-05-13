using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Hackaton_DW_2024.Infrastructure.Auth;

public class JwtTokenProvider : ITokenProvider
{
    int _tokenLifetime;
    string _signingKey;
    JwtSecurityTokenHandler _handler;

    public JwtTokenProvider(AuthTokenConfiguration config)
    {
        _tokenLifetime = config.DurationInMinutes;
        _signingKey = config.SigningKey;
        _handler = new JwtSecurityTokenHandler();
    }
    
    public string ProvideToken(TokenClaims claims)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signingKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
        (null,
            null,
            new []
            {
                new Claim("id", claims.UserId.ToString()),
            },
            expires: DateTime.Now.AddMinutes(_tokenLifetime),
            signingCredentials: credentials
        );

        return _handler.WriteToken(token);
    }

    public Dictionary<string, string> GetClaims(string token)
    {
        var jwtSecurityToken = _handler.ReadJwtToken(token);
        var claims = jwtSecurityToken.Claims.Select(claim => (claim.Type, claim.Value)).ToList();

        var result = new Dictionary<string, string>();
        foreach (var claim in claims)
        {
            result.Add(claim.Type, claim.Value);
        }

        return result;
    }
}