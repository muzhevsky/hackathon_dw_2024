using Hackaton_DW_2024.Data.DataSources.Teachers;
using Hackaton_DW_2024.Data.DataSources.Users;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Converters;
using Hackaton_DW_2024.Internal.Entities.Users;
using Role = Hackaton_DW_2024.Internal.Entities.Users.Role;

namespace Hackaton_DW_2024.Infrastructure.Repositories.Database;

public class UserRepository
{
    IUsersDataSource _usersDataSource;
    ITeacherDataSource _teacherDataSource;
    IConverter<User, UserDto> _converter;

    public UserRepository(
        IUsersDataSource usersDataSource, 
        ITeacherDataSource teacherDataSource,
        IConverter<User, UserDto> converter)
    {
        _usersDataSource = usersDataSource;
        _converter = converter;
        _teacherDataSource = teacherDataSource;
    }

    public void CreateUser(User user)
    {
        var userDto = _converter.Convert(user);
        var id = _usersDataSource.InsertOne(userDto);
        user.Id = id;
    }

    public User? GetUser(int id)
    {
        var dto = _usersDataSource.SelectById(id);
        if (dto == null) return null;
        return _converter.ConvertBack(dto);
    }

    public User? GetUser(string login)
    {
        var dto = _usersDataSource.SelectByLogin(login);
        if (dto == null) return null;
        return _converter.ConvertBack(dto);
    }

    public Role GetRole(int id)
    {
        if (_teacherDataSource.SelectByUserId(id) != null) return Role.Teacher;
        return Role.Student;
    }
}