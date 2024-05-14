using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities.Users;

namespace Hackaton_DW_2024.Infrastructure.Auth;

public class TokenClaims
{
    public TokenClaims(int userId, Role role)
    {
        UserId = userId;
        Role = role;
    }

    public Role Role { get; set; }
    public int UserId { get; set; }
}