namespace Hackaton_DW_2024.Internal.Entities;

public class Achievement
{
    public int Id { get; set; }
    public int Score { get; set; }
    public int TeamSize {get; set; }
    public int UserId { get; set; }
    public string FilePath { get; set; }
}