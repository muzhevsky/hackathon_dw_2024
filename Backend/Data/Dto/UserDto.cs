using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Hackaton_DW_2024.Data.Dto;

[Table("users")]
public class UserDto
{
    [Column("id")]
    public int Id { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("surname")]
    public string Surname { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("patronymic")]
    public string? Patronymic { get; set; }
    [Column("password_hash")]
    public string PasswordHash { get; set; }
    [Column("salt")]
    public string Salt { get; set; }
    [Column("role_id")]
    public int RoleId { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}