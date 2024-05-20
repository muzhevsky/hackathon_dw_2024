namespace Hackaton_DW_2024.Api.StudentApi;

public class AddConnectedAchievementRequest
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public int ResultId { get; set; }
    public bool WithTeam { get; set; }
}