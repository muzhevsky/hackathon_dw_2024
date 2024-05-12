using System.ComponentModel.DataAnnotations.Schema;
using Hackaton_DW_2024.Data.Dto.Events;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.Dto.Achievements;

[Table("achievements_and_events")]
public class AchievementsAndEventsDto: Dto
{
    [Column("id")]
    public int Id { get; set; }
    [Column]
    public int AchievementId { get; set; }
    public AchievementDto Achievement { get; set; }
    [Column]
    public int EventId { get; set; }
    public EventDto Event { get; set; }
    
    static string _structureName = "achievements_and_events";
    public static string StructureName => _structureName;
}