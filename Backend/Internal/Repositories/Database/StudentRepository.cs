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

    public void CreateStudent(Student student, User user)
    {
        var userDto = _userToDtoConverter.Convert(user);
        var id = _studentsDataSource.Insert(
            new StudentDto
            {
                User = userDto,
                StudentId = student.StudentId,
                GroupId = student.GroupId,
            });

        student.Id = id;
        student.UserId = _studentsDataSource.SelectById(id).UserId;
    }

    public Student? GetStudent(int id)
    {
        var dto = _studentsDataSource.SelectById(id);
        if (dto == null) return null;
        var userDto = _usersDataSource.SelectById(dto.UserId);
        var student = new Student()
        {
            UserId = dto.UserId,
            StudentId = dto.StudentId,
            GroupId = dto.GroupId,
            Surname = userDto.Surname,
            Name = userDto.Name,
            Patronymic = userDto.Patronymic
        };
        return student;
    }

    public Student? GetStudentByUserId(int userId)
    {
        var dto = _studentsDataSource.SelectByUserId(userId);
        if (dto == null) return null;
        var userDto = _usersDataSource.SelectById(dto.UserId);
        var student = new Student
        {
            UserId = userId,
            StudentId = dto.StudentId,
            GroupId = dto.GroupId,
            Surname = userDto.Surname,
            Name = userDto.Name,
            Patronymic = userDto.Patronymic
        };
        return student;
    }
}