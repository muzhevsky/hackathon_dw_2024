using Hackaton_DW_2024.Data.Dto.Users;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Users;

public interface IUsersDataSource
{
    EfUserDto? SelectById(int id);
    EfUserDto? SelectByLogin(string login);
    int InsertOne(EfUserDto item);
    void InsertMany(IEnumerable<EfUserDto> items);
    void UpdateById(int id, Action<EfUserDto> updateFunc);
    void DeleteById(int id);
}