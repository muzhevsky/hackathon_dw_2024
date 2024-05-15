using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UsersAndEvents;

public class EfUsersAndEventsDataSource:  IUsersAndEventsDataSource
{
    IDbContextFactory<ApplicationContext> _factory;
    public EfUsersAndEventsDataSource(IDbContextFactory<ApplicationContext>  context)
    {
        _factory = context;
    }

    public UsersAndEventsDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.UsersAndEvents.FirstOrDefault(dto => dto.Id == id);
    }

    public UsersAndEventsDto? SelectByUserIdAndEventId(int userId, int eventId)
    {
        using var context = _factory.CreateDbContext();
        return context.UsersAndEvents.FirstOrDefault(dto => dto.UserId == userId && dto.EventId == eventId);
    }

    public IEnumerable<UsersAndEventsDto> SelectByUserId(int userId)
    {
        using var context = _factory.CreateDbContext();
        return context.UsersAndEvents.Where(dto => dto.UserId == userId).ToList();
    }

    public void Insert(UsersAndEventsDto dto)
    {
        using var context = _factory.CreateDbContext();
        context.UsersAndEvents.Add(dto);
        context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        using var context = _factory.CreateDbContext();
        var deleteTarget = SelectById(id);
        if (deleteTarget == null) return;
        context.UsersAndEvents.Remove(deleteTarget);
        context.SaveChanges();
    }
}