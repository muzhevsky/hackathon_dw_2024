using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UsersAndEvents;

public class EfUsersAndEventsDataSource: EntityFrameworkDataSource, IUsersAndEventsDataSource
{
    DbSet<UsersAndEventsDto> _usersAndEvents;
    public EfUsersAndEventsDataSource(ApplicationContext context) : base(context)
    {
        _usersAndEvents = context.UsersAndEvents;
    }

    public UsersAndEventsDto? SelectById(int id)
    {
        return _usersAndEvents.FirstOrDefault(dto => dto.Id == id);
    }

    public UsersAndEventsDto? SelectByUserIdAndEventId(int userId, int eventId)
    {
        return _usersAndEvents.FirstOrDefault(dto => dto.UserId == userId && dto.EventId == eventId);
    }

    public IEnumerable<UsersAndEventsDto> SelectByUserId(int userId)
    {
        return _usersAndEvents.Where(dto => dto.UserId == userId);
    }

    public void Insert(UsersAndEventsDto dto)
    {
        _usersAndEvents.Add(dto);
        Context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var deleteTarget = SelectById(id);
        if (deleteTarget == null) return;
        _usersAndEvents.Remove(deleteTarget);
        Context.SaveChanges();
    }
}