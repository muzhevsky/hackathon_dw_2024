namespace Hackaton_DW_2024.Internal.Entities;

public class GroupDetails
{
    public Group Group { get; set; }
    public Department Department { get; set; }
    public Institute Institute { get; set; }
    public Speciality Speciality { get; set; }
    public int Course
    {
        get
        {
            var split = Group.Title.Split("-");
            return int.Parse(split[split.Length - 1][0].ToString());
        }
    }
}