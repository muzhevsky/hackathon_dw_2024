namespace Hackaton_DW_2024.Api.StudentApi;

public class AddCustomAchievementRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Date { get; set;}
    public int StatusId { get; set; }
    public int ResultId { get; set; }
    public bool WithTeam { get; set; }
}