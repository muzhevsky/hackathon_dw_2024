using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Data.DataSources.StudentsDS;

public class StudentByIdQuery
{
    public int Id { get; set; }
}

public class StudentByStudentIdQuery
{
    public string StudentId { get; set; }
}

public class StudentByUserIdQuery
{
    public int UserId { get; set; }
}

public class CreateStudentCommand
{
    public User User { get; set; }
    public Student Student { get; set; }
}