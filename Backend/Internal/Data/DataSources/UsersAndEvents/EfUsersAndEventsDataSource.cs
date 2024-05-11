using Hackaton_DW_2024.Internal.Data.Config;
using Hackaton_DW_2024.Internal.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Data.Package;
using Microsoft.EntityFrameworkCore;
using ILogger = Hackaton_DW_2024.Infrastructure.Logging.ILogger;

namespace Hackaton_DW_2024.Internal.Data.DataSources.UsersAndEvents;

public class EfUsersAndEventsDataSource : EntityFrameworkDataSource, IUsersAndEventsDataSource
{
    DbSet<UsersAndEventsDto> UsersAndEvents;

    public EfUsersAndEventsDataSource(DatabaseConnectionConfig config, ILogger logger) : base(config, logger)
    {
    }

    public IEnumerable<UsersAndEventsDto> SelectByUserId(int userId) =>
        UsersAndEvents.Where(dto => dto.UserId == userId);

    public IEnumerable<UsersAndEventsDto> SelectByEventId(int eventId) =>
        UsersAndEvents.Where(dto => dto.EventId == eventId);

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
        if (deleteTarget == null)
        {
            RaiseNotFoundError(UserDto.StructureName,
                new List<KeyValuePair<string, object>>
                {
                    new(nameof(dto.UserId), dto.UserId),
                    new(nameof(dto.EventId), dto.EventId)
                });
        }

        UsersAndEvents.Remove(deleteTarget);
    }
}