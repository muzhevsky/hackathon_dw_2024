using Hackaton_DW_2024.Internal.Data.Dto.Users;

namespace Hackaton_DW_2024.Internal.Data.DataSources.UsersAndEvents;

public interface IUsersAndEventsDataSource
{
    IEnumerable<UsersAndEventsDto> SelectByUserId(int userId);
    IEnumerable<UsersAndEventsDto> SelectByEventId(int eventId);
    void Insert(UsersAndEventsDto dto);
    void Delete(UsersAndEventsDto dto);
}