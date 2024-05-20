using Hackaton_DW_2024.Data.Dto.Events;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Events.Results;

public interface IEventResultsDataSource
{
    EventResultDto? SelectById(int id);
    IEnumerable<EventResultDto> SelectAll();
}