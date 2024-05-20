using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto.Users.Hierarchy;

[Table("specialities")]
public class SpecialityDto
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("title")]
    public string Title { get; set; }
    [Column("full_title")]
    public string FullTitle { get; set; }
}