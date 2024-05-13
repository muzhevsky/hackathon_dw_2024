using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto.Achievements;

[Table("achievements_and_events")]
public class AchievementsAndEventsDto: Dto
{
    [Column("id")]
    public int Id { get; set; }
    [Column("achievement_id")]
    public int AchievementId { get; set; }
    [Column("event_id")]
    public int EventId { get; set; }
    
    static string _structureName = "achievements_and_events";
    public static string StructureName => _structureName;
}