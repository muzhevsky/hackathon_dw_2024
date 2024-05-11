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
    
    public string ProvideToken(Dictionary<string, string> claims)
    {
        claims.Remove("iss", out var issue);
        claims.Remove("aud", out var audience);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signingKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
        (issue,
            audience,
            claims.Select(kv => new Claim(kv.Key, kv.Value)),
            expires: DateTime.Now.AddMinutes(_tokenLifetime),
            signingCredentials: credentials
        );

        return _handler.WriteToken(token);
    }
}