using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Dto.Users;

namespace Hackaton_DW_2024.Data.DataSources.Users;

public interface IUsersDataSource
{
    UserDto? SelectById(int id);
    UserDto? SelectByLogin(string login);
    int InsertOne(UserDto item);
    void InsertMany(IEnumerable<UserDto> items);
    void UpdateById(int id, Action<UserDto> updateFunc);
    void DeleteById(int id);
}