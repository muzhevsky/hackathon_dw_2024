using Hackaton_DW_2024.Data.Dto.Customization;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.CustomizationItems;

public class EfCustomizationItemsDataSource : EntityFrameworkDataSource, ICustomizationItemsDataSource
{
    protected DbSet<CustomizationItemDto> Items { get; set; }

    public EfCustomizationItemsDataSource(DatabaseConnectionConfig config) : base(config)
    {
    }

    public CustomizationItemDto? SelectById(int id) => Items.FirstOrDefault(dto => dto.Id == id);

    public List<CustomizationItemDto> SelectAll() => Items.ToList();
    public void InsertOne(CustomizationItemDto dto)
    {
        Items.Add(dto);
        SaveChanges();
    }

    public void DeleteById(int id)
    {
        var deleteTarget = Items.FirstOrDefault(dto => dto.Id == id);
        if (deleteTarget == null)
            throw new Exception("no entity found");
        Items.Remove(deleteTarget);
        SaveChanges();
    }
}