using Hackaton_DW_2024.Data.DataSources.UsersDS;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Infrastructure.Repositories;

public class UsersRepository
{
    ICommandExecutor<UserByIdQuery, User> _findUserByIdQueryExecutor;
    ICommandExecutor<UserByLoginQuery, User> _findUserByLoginExecutor;

    public UsersRepository(
        ICommandExecutor<UserByIdQuery, User> findUserByIdQueryExecutor, 
        ICommandExecutor<UserByLoginQuery, User> findUserByLoginExecutor)
    {
        _findUserByIdQueryExecutor = findUserByIdQueryExecutor;
        _findUserByLoginExecutor = findUserByLoginExecutor;
    }
    
    public User? GetUser(int id)
    {
        var user = _findUserByIdQueryExecutor.Execute(new UserByIdQuery {Id = id});
        return user;
    }

    public User? GetUserByLogin(string login)
    {
        var user = _findUserByLoginExecutor.Execute(new UserByLoginQuery {Login = login});
        return user;
    }
}