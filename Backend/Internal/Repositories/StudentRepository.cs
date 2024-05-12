using Hackaton_DW_2024.Data.DataSources.Students;
using Hackaton_DW_2024.Data.DataSources.Users;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.UseCases.Converters;

namespace Hackaton_DW_2024.Internal.Repositories;

public class StudentRepository
{
    IConverter<User, UserDto> _userConverter;
    IConverter<Student, StudentDto> _studentConverter;
    IUsersDataSource _usersDataSource;
    IStudentsDataSource _studentsDataSource;

    public StudentRepository(
        IUsersDataSource usersDataSource,
        IStudentsDataSource studentsDataSource, 
        IConverter<Student, StudentDto> studentConverter, 
        IConverter<User, UserDto> userConverter)
    {
        _usersDataSource = usersDataSource;
        _studentsDataSource = studentsDataSource;
        _studentConverter = studentConverter;
        _userConverter = userConverter;
    }

    public User? GetUser(string login)
    {
        var dto = _usersDataSource.SelectByLogin(login);
        if (dto == null) return null;
        return new User
        {
            Login = dto.Login,
            Password = dto.Password,
            Surname = dto.Surname,
            Name = dto.Name,
            Patronymic = dto.Patronymic,
            Salt = dto.Salt
        };
    }

    public int CreateStudent(Student student)
    {
        // var id = _usersDataSource.InsertOne(_userConverter.Convert(student.UserData));
        var id = _studentsDataSource.Insert(_studentConverter.Convert(student));
        return _studentsDataSource.SelectById(id)!.Id;
    }
}