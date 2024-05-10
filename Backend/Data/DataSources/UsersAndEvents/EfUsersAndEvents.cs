using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UsersAndEvents;

public class EfUsersAndEvents : EntityFrameworkDataSource, IUsersAndEvents
{
    DbSet<UsersAndEventsDto> UsersAndEvents;

    public EfUsersAndEvents(DatabaseConnectionConfig config) : base(config)
    {
    }

    public IEnumerable<UsersAndEventsDto> SelectByUserId(int userId) =>
        UsersAndEvents.Where(dto => dto.UserId == userId);

    public IEnumerable<UsersAndEventsDto> SelectByEventId(int eventId) =>
        UsersAndEvents.Where(dto => dto.EventId == eventId).ToList();

    public void Insert(UsersAndEventsDto dto)
    {
        UsersAndEvents.Add(dto);
        SaveChanges();
    }

    public void Delete(UsersAndEventsDto dto)
    {
        var deleteTarget =
            UsersAndEvents.FirstOrDefault(
                record =>
                    dto.UserId == record.UserId &&
                    dto.EventId == record.EventId
            );
        if (deleteTarget == null) throw new Exception("no entity found");
        UsersAndEvents.Remove(deleteTarget);
    }
}