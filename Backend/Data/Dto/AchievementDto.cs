using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto;

[Table("achievements")]
public class AchievementDto
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("user_id")]
    public int UserId { get; set; }
    
    [Column("file_name")]
    public string FileName { get; set; }
    
    [Column("score")]
    public int Score { get; set; }
}