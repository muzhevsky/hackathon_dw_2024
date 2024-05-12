namespace Hackaton_DW_2024.Internal.Entities;

public class Student
{
    public User UserData { get; set; }
    public Group? Group { get; set; }
    public string StudentId { get; set; }
    public string Telegram { get; set; }
}