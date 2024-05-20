using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto.Users.Hierarchy;

[Table("groups")]
public class GroupDto
{
    [Column("id")] 
    public int Id { get; set; }
    
    [Column("department_id")]
    public int DepartmentId { get; set; }
    
    [MaxLength(16)] 
    [Column("title")] 
    public string Title { get; set; }
    
    [Column("speciality_id")]
    public int SpecialityId { get; set; }
}