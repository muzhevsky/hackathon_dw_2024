using Hackaton_DW_2024.Data.DataSources.TeachersDS;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Infrastructure.Repositories;

public class TeachersRepository
{
    ICommandExecutor<Teacher, int> _create;
    ICommandExecutor<CreateTeacherWithUserCommand, int> _createWithUser;
    
    ICommandExecutor<TeacherByIdQuery, Teacher> _getById;
    ICommandExecutor<TeacherByUserIdQuery, Teacher> _getByUserId;
    ICommandExecutor<TeacherByDepartmentIdQuery, List<Teacher>> _getByDepartmentId;

    public TeachersRepository(
        ICommandExecutor<Teacher, int> create, 
        ICommandExecutor<CreateTeacherWithUserCommand, int> createWithUser,
        ICommandExecutor<TeacherByIdQuery, Teacher> getById, 
        ICommandExecutor<TeacherByUserIdQuery, Teacher> getByUserId, 
        ICommandExecutor<TeacherByDepartmentIdQuery, List<Teacher>> getByDepartmentId)
    {
        _create = create;
        _getById = getById;
        _getByUserId = getByUserId;
        _getByDepartmentId = getByDepartmentId;
        _createWithUser = createWithUser;
    }

    public void CreateTeacher(Teacher teacher)
    {
        _create.Execute(teacher);
    }
    
    public void CreateTeacherWithUser(Teacher teacher, User user)
    {
        var id = _createWithUser.Execute(new CreateTeacherWithUserCommand
        {
            Teacher = teacher,
            User = user
        });
        teacher.Id = id;
    }

    public Teacher GetById(int id)
    {
        var teacher = _getById.Execute(new TeacherByIdQuery{ Id = id});
        return teacher;
    }

    public Teacher GetByUserId(int userId)
    {
        var teacher = _getByUserId.Execute(new TeacherByUserIdQuery { UserId = userId});
        return teacher;
    }

    public List<Teacher> GetByDepartment(int departmentId)
    {
        return _getByDepartmentId.Execute(new TeacherByDepartmentIdQuery {DepartmentId = departmentId});
    }
}