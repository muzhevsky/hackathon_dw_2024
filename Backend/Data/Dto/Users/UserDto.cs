using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Dto.Events;

namespace Hackaton_DW_2024.Data.Dto.Users;

[Table("users")]
public class UserDto: Dto
{
    [Column("id")] 
    public int Id { get; set; }
    
    [Column("login")] 
    [MaxLength(64)] 
    public string Login { get; set; }
    
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
    public string Password { get; set; }

    [Column("salt")] 
    [MaxLength(128)] 
    public string Salt { get; set; }


    static string _structureName = "users";
    public static string StructureName => _structureName;
}