using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto.Users.Hierarchy;

[Table("departments")]
public class DepartmentDto
{
    [Column("id")] 
    public int Id { get; set; }
    
    [Column("institute_id")]
    public int InstituteId { get; set; }
    
    [MaxLength(16)] 
    [Column("title")] 
    public string Title { get; set; }
    
    [Column("full_title")]
    public string FullTitle { get; set; }
}