using System.IdentityModel.Tokens.Jwt;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Repositories.Database;
using Hackaton_DW_2024.Internal.Entities.Users;

namespace Hackaton_DW_2024.Api;

public static class AddAuthMiddlewareExtension
{
}

public class AuthMiddleware : IMiddleware
{
    readonly RequestDelegate _next;
    readonly UserRepository _userRepository;

    public AuthMiddleware(RequestDelegate next, UserRepository userRepository)
    {
        _next = next;
        _userRepository = userRepository;
    }

    void AttachUserToContext(HttpContext context, string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

        if (jwtToken == null) return;
        
        var claims = jwtToken.Claims;
        var idClaim = claims.FirstOrDefault(x => x.Type == "id")?.Value;
        if (idClaim == null) return;
        if (!int.TryParse(idClaim, out var id)) return;

        var role = _userRepository.GetRole(id);

        context.Items["id"] = id;
        context.Items["role"] = (int)role;
        context.User.IsInRole(role.ToString());
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            AttachUserToContext(context, token);
        }

        await _next(context);
    }
}