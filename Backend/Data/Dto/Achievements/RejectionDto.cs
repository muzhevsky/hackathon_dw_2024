using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto.Achievements;

[Table("rejections")]
public class RejectionDto: Dto
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("request_id")]
    public int RequestId { get; set; }

    [Column("reason")] 
    public string Reason { get; set; }
    
    [Column("date")]
    public DateTime Date { get; set; }
    
    static string _structureName = "rejections";
    public static string StructureName => _structureName;
}