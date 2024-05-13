using Hackaton_DW_2024.Data.Dto.Customization;

namespace Hackaton_DW_2024.Data.DataSources.CustomizationItems;

public interface ICustomizationItemsDataSource
{
    CustomizationItemDto? SelectById(int id);
    List<CustomizationItemDto> SelectAll();
    void InsertOne(CustomizationItemDto dto);
    void DeleteById(int id);
}