using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto;

[Table("customization_items")]
public class CustomizationItemDto
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("title")]
    [MaxLength(128)]
    public string Title { get; set; }
    
    [Column("file_path")]
    [MaxLength(128)]
    public int FilePath { get; set; }
}