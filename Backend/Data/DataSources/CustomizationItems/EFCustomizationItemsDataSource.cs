using Hackaton_DW_2024.Data.Dto;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.CustomizationItems;

public class EFCustomizationItemsDataSource : EntityFrameworkDataSource, ICustomizationItemsDataSource
{
    protected DbSet<CustomizationItemDto> Items { get; set; }

    public EFCustomizationItemsDataSource(DatabaseConnectionConfig config) : base(config)
    {
    }

    public CustomizationItemDto? SelectById(int id)
    {
        return Items.FirstOrDefault(dto => dto.Id == id);
    }

    public List<CustomizationItemDto> SelectAll()
    {
        return Items.ToList();
    }
}