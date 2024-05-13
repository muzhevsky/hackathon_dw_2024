using System.ComponentModel.DataAnnotations.Schema;
using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;

namespace Hackaton_DW_2024.Data.Dto.Users;

[Table("students")]
public class StudentDto
{
    [Column("id")]
    public int Id { get; set; }
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("student_id")] 
    public string StudentId { get; set; }
    
    [Column("group_id")]
    public int GroupId { get; set; }

    [Column("telegram_id")]
    public string? Telegram { get; set; }
    
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }
}