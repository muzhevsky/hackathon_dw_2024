using Hackaton_DW_2024.Data.Dto;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.CustomizationItems;

public class EfUserItemsDataSources : EntityFrameworkDataSource, IUserItemsDataSource
{
    protected DbSet<UserItemsDto> Purchases { get; set; }

    public EfUserItemsDataSources(DatabaseConnectionConfig config) : base(config)
    {
    }

    public List<UserItemsDto> SelectByUserId(int userId)
    {
        return Purchases.Where(dto => dto.UserId == userId).ToList();
    }

    public void InsertOne(UserItemsDto dto)
    {
        Purchases.Add(dto);
    }

    public void InsertMany(IEnumerable<UserItemsDto> dtos)
    {
        Purchases.AddRange(dtos);
    }
}