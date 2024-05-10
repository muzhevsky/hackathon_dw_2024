using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.Dto.Events;

[Table("news_and_events")]
[Keyless]
public class NewsAndEventsDto: Dto
{
    [Column("news_id")]
    public int NewsId { get; set; }
    
    [Column("event_id")]
    public int EventId { get; set; }
    
    static string _structureName = "news_and_events";
    public static string StructureName => _structureName;
}