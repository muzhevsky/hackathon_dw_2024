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
    public string FileName { get; set; }
    
    [Column("score")]
    public int Score { get; set; }
}