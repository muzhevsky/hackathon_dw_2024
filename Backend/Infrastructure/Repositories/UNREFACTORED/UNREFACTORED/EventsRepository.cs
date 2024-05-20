using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Events;
using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Events.Results;
using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Events.Statuses;
using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.UsersAndEvents;
using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Dto.Users;

namespace Hackaton_DW_2024.Infrastructure.Repositories.UNREFACTORED;

public class EventsRepository
{
    IEventsDataSource _eventsDataSource;
    IEventStatusesDataSource _eventStatusesDataSource;
    IUsersAndEventsDataSource _usersAndEventsDataSource;
    IEventResultsDataSource _eventResultsDataSource;

    public EventsRepository(
        IEventStatusesDataSource eventStatusesDataSource,
        IEventResultsDataSource eventResultsDataSource,
        IEventsDataSource eventsDataSource,
        IUsersAndEventsDataSource usersAndEventsDataSource)
    {
        _eventStatusesDataSource = eventStatusesDataSource;
        _eventResultsDataSource = eventResultsDataSource;
        _eventsDataSource = eventsDataSource;
        _usersAndEventsDataSource = usersAndEventsDataSource;
    }

    public List<EventStatusDto> GetAllStatuses()
    {
        return _eventStatusesDataSource.SelectAll().ToList();
    }

    public EventStatusDto? GetStatusById(int id)
    {
        return _eventStatusesDataSource.SelectById(id);
    }

    public List<EventResultDto> GetAllResults()
    {
        return _eventResultsDataSource.SelectAll().ToList();
    }

    public EventResultDto? GetResultById(int id)
    {
        return _eventResultsDataSource.SelectById(id);
    }

    public List<EventDto> GetAll()
    {
        return _eventsDataSource.SelectAll().ToList();
    }

    public List<EventDto> GetByUserId(int userId)
    {
        var usersAndEvents = _usersAndEventsDataSource.SelectByUserId(userId);
        var result = new List<EventDto>();
        foreach (var ue in usersAndEvents)
        {
            result.Add(_eventsDataSource.SelectById(ue.EventId));
        }

        return result;
    }

    public void AddToUser(int eventId, int userId)
    {
        var stored = _usersAndEventsDataSource.SelectByUserIdAndEventId(userId, eventId);
        if (stored != null) return;
        _usersAndEventsDataSource.Insert(new UsersAndEventsDto
        {
            EventId = eventId, UserId = userId
        });
    }
    
    public void RemoveFromUser(int eventId, int userId)
    {
        var stored = _usersAndEventsDataSource.SelectByUserIdAndEventId(userId, eventId);
        if (stored == null) return;
        _usersAndEventsDataSource.DeleteById(stored.Id);
    }
}