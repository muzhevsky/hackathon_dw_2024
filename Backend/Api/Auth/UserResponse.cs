namespace Hackaton_DW_2024.Api.Auth;

public class UserResponse
{
    public int Id { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string? Patronymic { get; set; }
    public string Role { get; set; }
}