using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Users;

public class EfUserDataSource :  IUsersDataSource
{
    IDbContextFactory<ApplicationContext> _factory;

    public EfUserDataSource(IDbContextFactory<ApplicationContext>  context)
    {
        _factory = context;
    }

    public EfUserDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.Users.FirstOrDefault(dto => dto.Id == id);
    }

    public EfUserDto? SelectByLogin(string login)
    {
        using var context = _factory.CreateDbContext();
        return context.Users.FirstOrDefault(dto => dto.Login == login);
    }

    public int InsertOne(EfUserDto item)
    {
        using var context = _factory.CreateDbContext();
        context.Users.Add(item);
        context.SaveChanges();
        return item.Id;
    }

    public void InsertMany(IEnumerable<EfUserDto> items)
    {
        using var context = _factory.CreateDbContext();
        context.Users.AddRange(items);
        context.SaveChanges();
    }

    public void UpdateById(int id, Action<EfUserDto> updateFunc)
    {
        using var context = _factory.CreateDbContext();
        var updateTarget = SelectById(id);
        updateFunc(updateTarget);
        context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        using var context = _factory.CreateDbContext();
        var deleteTarget = SelectById(id);
        context.Users.Remove(deleteTarget);
        context.SaveChanges();
    }
}