using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public string? FilePath { get; set; }
    
    [Column("score")]
    public int Score { get; set; }
    
    [Column("with_team")]
    public bool WithTeam { get; set; }
    
    [Column("result_id")]
    public int ResultId { get; set; }
    
    [Column("event_id")]
    public int? EventId { get; set; }

    List<QuestDto> Quests { get; set; }
    
    static string _structureName = "achievements";
    public static string StructureName => _structureName;
}