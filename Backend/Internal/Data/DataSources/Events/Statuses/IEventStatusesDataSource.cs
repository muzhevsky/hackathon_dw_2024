using Hackaton_DW_2024.Internal.Data.Dto.Events;

namespace Hackaton_DW_2024.Internal.Data.DataSources.Events.Statuses;

public interface IEventStatusesDataSource
{
    IEnumerable<EventStatusDto> SelectAll();
    EventStatusDto? SelectById(int id);
}