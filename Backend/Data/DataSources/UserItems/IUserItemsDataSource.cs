using Hackaton_DW_2024.Data.Dto.Customization;

namespace Hackaton_DW_2024.Data.DataSources.UserItems;

public interface IUserItemsDataSource
{
    List<UserItemsDto> SelectByUserId(int userId);
    void InsertOne(UserItemsDto dto);
    void InsertMany(IEnumerable<UserItemsDto> dtos);
}