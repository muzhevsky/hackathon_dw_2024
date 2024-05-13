namespace Hackaton_DW_2024.Api.Responses;

public class StudentSignUpResponse
{
    public StudentSignUpResponse(string token)
    {
        Token = token;
    }

    public string Token { get; set; }
}