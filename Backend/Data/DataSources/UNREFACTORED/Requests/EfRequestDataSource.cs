using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Requests;

public class EfRequestDataSource :  IRequestDataSource
{
    IDbContextFactory<ApplicationContext> _factory;

    public EfRequestDataSource(IDbContextFactory<ApplicationContext>  context)
    {
        _factory = context;
    }

    public RequestDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.Requests.FirstOrDefault(dto => dto.Id == id);
    }

    public IEnumerable<RequestDto> SelectByUserId(int userId)
    {
        using var context = _factory.CreateDbContext();
        return context.Requests.Where(dto => dto.UserId == userId).ToList();
    }

    public void Insert(RequestDto dto)
    {
        using var context = _factory.CreateDbContext();
        context.Requests.Add(dto);
        context.SaveChanges();
    }

    public void UpdateById(int id, Action<RequestDto> updateFunc)
    {
        using var context = _factory.CreateDbContext();
        var updateTarget = context.Requests.FirstOrDefault(dto => dto.Id == id);
        updateFunc(updateTarget);
        context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        using var context = _factory.CreateDbContext();
        var deleteTarget = context.Requests.FirstOrDefault(dto => dto.Id == id);
        context.Requests.Remove(deleteTarget);
        context.SaveChanges();
    }
}