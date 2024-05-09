using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.Dto;

[Table("news_and_events")]
[Keyless]
public class NewsAndEvents
{
    [Column("news_id")]
    public int NewsId { get; set; }
    
    [Column("event_id")]
    public int EventId { get; set; }
}