using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto.Events;

[Table("event_results")]
public class EventResultDto
{
    [Column("id")]
    public int Id { get; set; }
    [Column("title")]
    public string Title { get; set; }
    [Column("score")]
    public int Score { get; set; }
}