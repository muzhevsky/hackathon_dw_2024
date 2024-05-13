namespace Hackaton_DW_2024.Api.Auth;

public class SignInResponse
{
    public SignInResponse(UserResponse user, string token)
    {
        Token = token;
        User = user;
    }

    public string Token { get; set; }
    public UserResponse User { get; set; }
}