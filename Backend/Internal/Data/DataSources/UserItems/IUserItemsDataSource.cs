using Hackaton_DW_2024.Internal.Data.Dto.Customization;

namespace Hackaton_DW_2024.Internal.Data.DataSources.UserItems;

public interface IUserItemsDataSource
{
    IEnumerable<UserItemsDto> SelectByUserId(int userId);
    void InsertOne(UserItemsDto dto);
    void InsertMany(IEnumerable<UserItemsDto> dtos);
}