using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.Dto.Events;

[Table("news_and_events")]
public class NewsAndEventsDto: Dto
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("news_id")]
    public int NewsId { get; set; }
    public NewsDto News { get; set; }
    
    [Column("event_id")]
    public int EventId { get; set; }
    public EventDto Event { get; set; }
    
    static string _structureName = "news_and_events";
    public static string StructureName => _structureName;
}