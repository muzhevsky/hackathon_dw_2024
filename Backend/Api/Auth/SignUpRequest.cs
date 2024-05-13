namespace Hackaton_DW_2024.Api.Auth;

public class SignUpRequest
{
    public string StudentId { get; set; }
    public string Password { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public int GroupId { get; set; }
}
