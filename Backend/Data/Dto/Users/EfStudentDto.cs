using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto.Users;

[Table("students")]
public class EfStudentDto
{
    [Column("id")]
    public int Id { get; set; }
    [Column("user_id")]
    [ForeignKey("User")]
    public int UserId { get; set; }

    [Column("student_id")] 
    public string StudentId { get; set; }
    
    [Column("group_id")]
    public int GroupId { get; set; }

    [Column("telegram_id")]
    public string? Telegram { get; set; }
    
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }
    
    public EfUserDto User { get; set; }
}