using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto.Achievements;

[Table("requests")]
public class RequestDto: Dto
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("user_id")]
    public int UserId { get; set; }
    
    [Column("rejected")]
    public bool Rejected { get; set; }
    
    static string _structureName = "requests";
    public static string StructureName => _structureName;
}