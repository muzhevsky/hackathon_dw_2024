using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto.Achievements;

[Table("custom_achievements")]
public class CustomAchievementDto
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("achievement_id")]
    public int AchievementId { get; set; }
    
    [Column("title")]
    public string Title { get; set; }
    
    [Column("date")]
    public DateTime Date { get; set; }
    
    [Column("status_id")]
    public int StatusId { get; set; }
}