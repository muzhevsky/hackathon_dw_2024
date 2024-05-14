using Hackaton_DW_2024.Data.Dto.Users;

namespace Hackaton_DW_2024.Data.DataSources.UsersAndEvents;

public interface IUsersAndEventsDataSource
{
    UsersAndEventsDto? SelectById(int id);
    UsersAndEventsDto? SelectByUserIdAndEventId(int userId, int eventId);
    IEnumerable<UsersAndEventsDto> SelectByUserId(int userId);
    void Insert(UsersAndEventsDto dto);
    void DeleteById(int id);
}