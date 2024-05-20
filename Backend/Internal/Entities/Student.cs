namespace Hackaton_DW_2024.Internal.Entities;

public class Student
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string StudentId { get; set; }
    public int GroupId { get; set; }
    public string? Telegram { get; set; }
    public string? PhoneNumber { get; set; }
}