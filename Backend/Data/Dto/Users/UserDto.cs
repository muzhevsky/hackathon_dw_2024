using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Hackaton_DW_2024.Data.Dto.Users;

[Table("users")]
public class UserDto: Dto
{
    [Column("id")] 
    public int Id { get; set; }
    
    [Column("email")] 
    [MaxLength(128)] 
    public string Email { get; set; }
    
    [Column("surname")] 
    [MaxLength(64)] 
    public string Surname { get; set; }
    
    [Column("name")] 
    [MaxLength(64)]
    public string Name { get; set; }
    
    [Column("patronymic")] 
    [MaxLength(64)] 
    public string? Patronymic { get; set; }

    [Column("password_hash")]
    [MaxLength(256)]
    public string PasswordHash { get; set; }

    [Column("salt")] 
    [MaxLength(128)] 
    public string Salt { get; set; }
    
    [Column("role_id")] 
    public int RoleId { get; set; }

    static string _structureName = "users";
    public static string StructureName => _structureName;
}