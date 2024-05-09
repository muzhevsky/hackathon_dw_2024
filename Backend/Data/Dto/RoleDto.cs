using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Hackaton_DW_2024.Data.Dto;

[Table("roles")]
public class RoleDto
{
    [Column("id")] 
    public int Id { get; set; }
    
    [Column("title")] 
    [MaxLength(32)] 
    public string Title { get; set; }


    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public enum Roles
{
    RoleUser = 0,
    RoleAdmin,
    RoleDeanery
}