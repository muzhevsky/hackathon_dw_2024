namespace Hackaton_DW_2024.Api.Student;

public class AddAchievementRequest
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public string Result { get; set; }
    public bool WithTeam { get; set; }
}