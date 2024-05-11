using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Internal.Data.Dto.Events;

[Table("events")]
public class EventDto: Dto
{
    [Column("id")] 
    public int Id { get; set; }
    
    [Column("title")]
    [MaxLength(256)]
    public string Title { get; set; }
    
    [Column("start_date")]
    public DateTime StartDate { get; set; }
    
    [Column("end_date")]
    public DateTime EndDate { get; set; }
    
    [Column("status_id")]
    public int StatusId { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
    
    static string _structureName = "events";
    public static string StructureName => _structureName;
}