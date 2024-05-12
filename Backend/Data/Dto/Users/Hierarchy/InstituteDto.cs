using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto.Users.Hierarchy;

[Table("institutes")]
public class InstituteDto
{
    [Column("id")] 
    public int Id { get; set; }
    
    [Column("title")] 
    [MaxLength(16)] 
    public string Title { get; set; }
}