using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Internal.Data.Dto.Achievements;

[Table("achievements_and_events")]
[Keyless]
public class AchievementsAndEventsDto: Dto
{
    [Column]
    public int AchievementId { get; set; }
    
    [Column]
    public int EventId { get; set; }
    
    
    static string _structureName = "achievements_and_events";
    public static string StructureName => _structureName;
}