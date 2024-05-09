using Hackaton_DW_2024.Data.Dto;

namespace Hackaton_DW_2024.Data.DataSources.CustomizationItems;

public interface ICustomizationItemsDataSource
{
    CustomizationItemDto? SelectById(int id);
    List<CustomizationItemDto> SelectAll();
}