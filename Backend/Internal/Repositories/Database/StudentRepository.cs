using Hackaton_DW_2024.Data.DataSources.Students;
using Hackaton_DW_2024.Data.DataSources.Users;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Converters;
using Hackaton_DW_2024.Internal.Entities.Users;

namespace Hackaton_DW_2024.Internal.Repositories.Database;

public class StudentRepository
{
    IConverter<User, UserDto> _userToDtoConverter;
    IStudentsDataSource _studentsDataSource;
    IUsersDataSource _usersDataSource;

    public StudentRepository(
        IStudentsDataSource studentsDataSource,
        IUsersDataSource usersDataSource,
        IConverter<User, UserDto> userToDtoConverter)
    {
        _studentsDataSource = studentsDataSource;
        _usersDataSource = usersDataSource;
        _userToDtoConverter = userToDtoConverter;
    }

    public void CreateStudent(Student student)
    {
        var id = _studentsDataSource.Insert(
            new StudentDto
            {
                UserId = student.UserId,
                StudentId = student.StudentId,
                GroupId = student.GroupId,
            });

        student.Id = id;
    }

    public Student? GetStudent(int id)
    {
        var dto = _studentsDataSource.SelectById(id);
        if (dto == null) return null;
        var student = new Student()
        {
            Id = dto.Id,
            UserId = dto.UserId,
            StudentId = dto.StudentId,
            GroupId = dto.GroupId,
            Telegram = dto.Telegram
        };
        return student;
    }

    public Student? GetStudentByUserId(int userId)
    {
        var dto = _studentsDataSource.SelectByUserId(userId);
        if (dto == null) return null;
        var student = new Student
        {
            Id = dto.Id,
            UserId = dto.UserId,
            StudentId = dto.StudentId,
            GroupId = dto.GroupId,
        };
        return student;
    }
}