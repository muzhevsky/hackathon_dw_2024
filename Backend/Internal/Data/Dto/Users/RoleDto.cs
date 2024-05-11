using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Internal.Data.Dto.Users;

[Table("roles")]
public class RoleDto: Dto
{
    [Column("id")] 
    public int Id { get; set; }
    
    [Column("title")] 
    [MaxLength(32)] 
    public string Title { get; set; }
    
    static string _structureName = "roles";
    public static string StructureName => _structureName;
}

public enum Role
{
    User,
    Admin,
    Deanery
}