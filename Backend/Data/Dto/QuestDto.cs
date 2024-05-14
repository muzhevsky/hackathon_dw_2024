using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto;

[Table("quests")]
public class QuestDto
{
    [Column("id")]
    public int Id { get; set; }
    [Column("teacher_id")]
    public int TeacherId { get; set; }
    [Column("event_id")]
    public int EventId { get; set; }
    [Column("result_id")]
    public int ResultId { get; set; }
    [Column("group_id")]
    public int GroupId { get; set; }
    [Column("description")]
    public string Description { get; set; }
}