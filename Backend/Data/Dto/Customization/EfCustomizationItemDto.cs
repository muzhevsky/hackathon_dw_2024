using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto.Customization;

[Table("customization_items")]
public class CustomizationItemDto: Dto
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("title")]
    [MaxLength(128)]
    public string Title { get; set; }
    
    [Column("price")]
    public int Price { get; set; }
    
    [Column("file_path")]
    [MaxLength(128)]
    public int FilePath { get; set; }
    
    static string _structureName = "customization_items";
    public static string StructureName => _structureName;
}