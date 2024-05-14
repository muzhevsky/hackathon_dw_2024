namespace Hackaton_DW_2024.Api.Teacher;

public class CreateQuestRequest
{
    public int EventId { get; set; }
    public int ResultId { get; set; }
    public int GroupId { get; set; }
    public string Description { get; set; }
}