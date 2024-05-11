using Hackaton_DW_2024.Internal.Data.DataSources.Users;
using Hackaton_DW_2024.Internal.Data.Dto.Users;

namespace Hackaton_DW_2024.Internal.Repositories;

public class UserRepository
{
    IUsersDataSource _usersDataSource;

    public UserRepository(IUsersDataSource usersDataSource)
    {
        _usersDataSource = usersDataSource;
    }

    public UserDto? GetUser(int id)
    {
        return _usersDataSource.SelectById(id);
    }
    
    public UserDto? GetUser(string email)
    {
        return _usersDataSource.SelectByEmail(email);
    }

    public int SaveUser(UserDto user)
    {
        user.Id = _usersDataSource.InsertOne(user);
        return user.Id;
    }
}