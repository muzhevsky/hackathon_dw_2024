using Hackaton_DW_2024.Internal.Data.Dto.Users;

namespace Hackaton_DW_2024.Internal.Data.DataSources.Users;

public interface IUsersDataSource
{
    UserDto? SelectById(int id);
    UserDto? SelectByEmail(string email);
    int InsertOne(UserDto item);
    void InsertMany(IEnumerable<UserDto> items);
    void UpdateById(int id, Action<UserDto> updateFunc);
    void DeleteById(int id);
}