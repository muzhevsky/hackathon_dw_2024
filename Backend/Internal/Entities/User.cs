using Hackaton_DW_2024.Data.Dto.Users;

namespace Hackaton_DW_2024.Internal.Entities;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string? Patronymic { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
}