namespace Hackaton_DW_2024.Internal.Entities.Users;

public class User
{
    public int Id { get; set; }
    string _login;
    public string Login { get => _login; set => _login = $"sstudurdom/{value}"; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string? Patronymic { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }

    public bool PasswordMatches(string password)
    {
        return Password == password;
    }
}