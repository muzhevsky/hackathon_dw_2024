namespace Hackaton_DW_2024.Internal.Entities;

public class AchievementForRequest
{
    public string Title { get; set; }
    public string Date { get; set; }
    public string Status { get; set; }
    public string TeamStatus { get; set; }
    public string Result { get; set; }

    public string[] ToArray()
    {
        return
        [
            Title, Date, Status, TeamStatus, Result
        ];
    }
}