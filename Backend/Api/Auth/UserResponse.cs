namespace Hackaton_DW_2024.Api.Auth;

public class UserResponse
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string? Patronymic { get; set; }
    public int Role { get; set; }
}