using Hackaton_DW_2024.Data.DataSources.Users;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.UseCases.Converters;

namespace Hackaton_DW_2024.Internal.Repositories;

public class UserRepository
{
    IUsersDataSource _usersDataSource;
    IConverter<User, UserDto> _userToDtoConverter;
    IConverter<UserDto, User> _userFromDtoConverter;

    public UserRepository(IConverter<User, UserDto> userToDtoConverter, IUsersDataSource usersDataSource, IConverter<UserDto, User> userFromDtoConverter)
    {
        _userToDtoConverter = userToDtoConverter;
        _usersDataSource = usersDataSource;
        _userFromDtoConverter = userFromDtoConverter;
    }

    public void CreateUser(User user)
    {
        var id = _usersDataSource.InsertOne(_userToDtoConverter.Convert(user));
        user.Id = id;
    }
    
    public User? GetUser(int id)
    {
        var dto = _usersDataSource.SelectById(id);
        if (dto == null) return null;

        return _userFromDtoConverter.Convert(dto);
    }
    
    public User? GetUser(string login)
    {
        var dto = _usersDataSource.SelectByLogin(login);
        if (dto == null) return null;

        return _userFromDtoConverter.Convert(dto);
    }
}