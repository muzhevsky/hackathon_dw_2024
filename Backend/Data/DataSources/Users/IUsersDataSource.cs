using Hackaton_DW_2024.Data.Dto;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Users;

public interface IUsersDataSource
{
    UserDto? SelectById(int id);
    UserDto? SelectByEmail(string email);
    void InsertOne(UserDto item);
    void InsertMany(IEnumerable<UserDto> items);
    void UpdateById(int id, Action<UserDto> updateFunc);
    void DeleteById(int id);
}