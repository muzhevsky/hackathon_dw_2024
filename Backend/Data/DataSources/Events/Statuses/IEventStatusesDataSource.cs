using Hackaton_DW_2024.Data.Dto;

namespace Hackaton_DW_2024.Data.DataSources.Events.Statuses;

public interface IEventStatusesDataSource
{
    IEnumerable<EventStatusDto> SelectAll();
    EventStatusDto? SelectById(int id);
}