using Hackaton_DW_2024.Data.Config;
using Hackaton_DW_2024.Data.Dto.Customization;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UserItems;

public class EfUserItemsDataSources : EntityFrameworkDataSource, IUserItemsDataSource
{
    protected DbSet<UserItemsDto> UserItems { get; set; }

    public EfUserItemsDataSources(ApplicationContext context) : base(context)
    {
        // UserItems = context.U
    }

    public IEnumerable<UserItemsDto> SelectByUserId(int userId) => UserItems.Where(dto => dto.UserId == userId);

    public void InsertOne(UserItemsDto dto)
    {
        UserItems.Add(dto);
        Context.SaveChanges();
    }

    public void InsertMany(IEnumerable<UserItemsDto> dtos)
    {
        UserItems.AddRange(dtos);
        Context.SaveChanges();
    }
}