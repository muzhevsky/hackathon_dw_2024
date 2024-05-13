using Hackaton_DW_2024.Data.DataSources.Users;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Converters;
using Hackaton_DW_2024.Internal.Entities.Users;

namespace Hackaton_DW_2024.Internal.Repositories.Database;

public class UserRepository
{
    IUsersDataSource _usersDataSource;
    IConverter<User, UserDto> _converterToDto;
    IConverter<UserDto, User> _converterFromDto;

    public UserRepository(
        IUsersDataSource usersDataSource, 
        IConverter<UserDto, User> converterFromDto,
        IConverter<User, UserDto> converterToDto)
    {
        _usersDataSource = usersDataSource;
        _converterFromDto = converterFromDto;
        _converterToDto = converterToDto;
    }

    public void CreateUser(User user)
    {
        var userDto = _converterToDto.Convert(user);
        var id = _usersDataSource.InsertOne(userDto);
        user.Id = id;
    }

    public User? GetUser(int id)
    {
        var dto = _usersDataSource.SelectById(id);
        if (dto == null) return null;
        return _converterFromDto.Convert(dto);
    }

    public User? GetUser(string login)
    {
        var dto = _usersDataSource.SelectByLogin(login);
        if (dto == null) return null;
        return _converterFromDto.Convert(dto);
    }
}