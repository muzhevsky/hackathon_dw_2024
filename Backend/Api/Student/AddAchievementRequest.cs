namespace Hackaton_DW_2024.Api.Student;

public class AddAchievementRequest
{
    public int? EventId { get; set; }
    public int? StatusId { get; set; }
    public int TeamSize { get; set; }
    public IFormFile? File { get; set; }
}