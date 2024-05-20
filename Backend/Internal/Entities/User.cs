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
    
    public bool CheckPassword(string password)
    {
        return Password == password;
    }

    public bool Validate()
    {
        throw new NotImplementedException("TODO"); // todo regex
        return ValidateLogin() && ValidateSurname() && ValidateName() && ValidatePatronymic() && ValidatePassword();
    }

    bool ValidateLogin()
    {
        return false;
    }

    bool ValidatePassword()
    {
        return false;
    }

    bool ValidateName()
    {
        return false;
    }

    bool ValidateSurname()
    {
        return false;
    }
    
    bool ValidatePatronymic()
    {
        return false;
    }
}