namespace Hackaton_DW_2024.Internal.Entities;

public class Group
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int DepartmentId { get; set; }
    public string Department { get; set; }
}