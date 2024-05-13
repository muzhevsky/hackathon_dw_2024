using Hackaton_DW_2024.Data.DataSources.Events.Results;
using Hackaton_DW_2024.Data.DataSources.Events.Statuses;
using Hackaton_DW_2024.Data.Dto.Events;

namespace Hackaton_DW_2024.Infrastructure.Repositories.Database;

public class EventsRepository
{
    IEventStatusesDataSource _eventStatusesDataSource;
    IEventResultsDataSource _eventResultsDataSource;

    public EventsRepository(
        IEventStatusesDataSource eventStatusesDataSource, 
        IEventResultsDataSource eventResultsDataSource
        )
    {
        _eventStatusesDataSource = eventStatusesDataSource;
        _eventResultsDataSource = eventResultsDataSource;
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
}