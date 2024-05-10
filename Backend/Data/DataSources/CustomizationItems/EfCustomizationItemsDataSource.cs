using Hackaton_DW_2024.Data.Dto.Customization;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;
using ILogger = Hackaton_DW_2024.Infrastructure.ILogger;

namespace Hackaton_DW_2024.Data.DataSources.CustomizationItems;

public class EfCustomizationItemsDataSource : EntityFrameworkDataSource, ICustomizationItemsDataSource
{
    protected DbSet<CustomizationItemDto> Items { get; set; }
    public EfCustomizationItemsDataSource(DatabaseConnectionConfig config, ILogger logger) : base(config, logger)
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
        {
            RaiseNotFoundError(CustomizationItemDto.StructureName,
                new List<KeyValuePair<string, object>>
                {
                    new(nameof(CustomizationItemDto.Id), id)
                });
            return;
        }
        Items.Remove(deleteTarget);
        SaveChanges();
    }
}