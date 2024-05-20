using Hackaton_DW_2024.Data.DataSources.StudentsDS;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Infrastructure.Repositories;

public class StudentsRepository
{
    ICommandExecutor<CreateStudentCommand, int> _create;
    
    ICommandExecutor<StudentByIdQuery, Student> _findById;
    ICommandExecutor<StudentByUserIdQuery, Student> _findByUserId;
    ICommandExecutor<StudentByStudentIdQuery, Student>  _findByStudentId;

    public StudentsRepository(
        ICommandExecutor<CreateStudentCommand, int> create,
        ICommandExecutor<StudentByIdQuery, Student> findById, 
        ICommandExecutor<StudentByUserIdQuery, Student> findByUserId, 
        ICommandExecutor<StudentByStudentIdQuery, Student> findByStudentId)
    {
        _create = create;
        _findById = findById;
        _findByUserId = findByUserId;
        _findByStudentId = findByStudentId;
    }

    public void CreateStudent(Student student, User user)
    {
        var id = _create.Execute(new CreateStudentCommand
        {
            Student = student,
            User = user
        });
        student.Id = id;
    }
    
    public Student? GetStudent(int id)
    {
        var student = _findById.Execute(new StudentByIdQuery {Id = id});
        return student;
    }
    
    public Student? GetStudentByStudentId(string studentId)
    {
        var student = _findByStudentId.Execute(new StudentByStudentIdQuery {StudentId = studentId});
        return student;
    }

    public Student? GetStudentByUserId(int userId)
    {
        var student = _findByUserId.Execute(new StudentByUserIdQuery {UserId = userId});
        return student;
    }
}