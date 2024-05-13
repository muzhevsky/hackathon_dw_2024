using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Users;

public class EfUserDataSource : EntityFrameworkDataSource, IUsersDataSource
{
    protected DbSet<UserDto> Users { get; set; }

    public EfUserDataSource(ApplicationContext context) : base(context)
    {
        Users = context.Users;
    }

    public UserDto? SelectById(int id) => Users.FirstOrDefault(dto => dto.Id == id);
    public UserDto? SelectByLogin(string login) => Users.FirstOrDefault(dto => dto.Login == login);

    public int InsertOne(UserDto item)
    {
        Users.Add(item);
        Context.SaveChanges();
        return item.Id;
    }

    public void InsertMany(IEnumerable<UserDto> items)
    {
        Users.AddRange(items);
        Context.SaveChanges();
    }

    public void UpdateById(int id, Action<UserDto> updateFunc)
    {
        var updateTarget = SelectById(id);

        updateFunc(updateTarget);
        Context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var deleteTarget = SelectById(id);

        Users.Remove(deleteTarget);
        Context.SaveChanges();
    }
}