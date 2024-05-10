using Hackaton_DW_2024.Data.Dto.Users;

namespace Hackaton_DW_2024.Data.DataSources.UsersAndEvents;

public interface IUsersAndEvents
{
    IEnumerable<UsersAndEventsDto> SelectByUserId(int userId);
    IEnumerable<UsersAndEventsDto> SelectByEventId(int eventId);
    void Insert(UsersAndEventsDto dto);
    void Delete(UsersAndEventsDto dto);
}