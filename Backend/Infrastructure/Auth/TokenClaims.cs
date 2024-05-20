namespace Hackaton_DW_2024.Infrastructure.Auth;

public class TokenClaims
{
    public TokenClaims(int userId)
    {
        UserId = userId;
    }

    public int UserId { get; set; }
}