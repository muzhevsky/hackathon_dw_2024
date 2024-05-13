using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hackaton_DW_2024.Data.Dto.Events;

namespace Hackaton_DW_2024.Data.Dto.Achievements;

[Table("achievements")]
public class AchievementDto: Dto
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("user_id")]
    public int UserId { get; set; }
    
    [Column("file_name")]
    [MaxLength(256)]
    public string? FileName { get; set; }
    
    [Column("score")]
    public int Score { get; set; }
    
    [Column("team_size")]
    public int TeamSize { get; set; }
    
    
    public List<EventDto> Events { get; set; }
    public List<AchievementsAndEventsDto> AchievementsAndEvents { get; set; }
    public List<RequestDto> Requests { get; set; }

    
    static string _structureName = "achievements";
    public static string StructureName => _structureName;
}