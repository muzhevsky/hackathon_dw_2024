using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Data.DataSources.TeachersDS;

public class TeacherByIdQuery
{
    public int Id { get; set; }
}

public class TeacherByUserIdQuery
{
    public int UserId { get; set; }
}

public class TeacherByDepartmentIdQuery
{
    public int DepartmentId { get; set; }
}

public class CreateTeacherWithUserCommand
{
    public Teacher Teacher { get; set; }
    public User User { get; set; }
}