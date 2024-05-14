namespace Hackaton_DW_2024.Internal.Entities;

public class Achievement
{
    public int Id { get; set; }
    public int Score { get; set; }
    public bool WithTeam {get; set; }
    public int UserId { get; set; }
    public string FilePath { get; set; }
    public int ResultId { get; set; }
}