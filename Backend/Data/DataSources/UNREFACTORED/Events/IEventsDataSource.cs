using Hackaton_DW_2024.Data.Dto.Events;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Events;

public interface IEventsDataSource
{
    EventDto? SelectById(int id);
    IEnumerable<EventDto> SelectAll();
    IEnumerable<EventDto> SelectActive();
    IEnumerable<EventDto> SelectByStatusId(int statusId);
    IEnumerable<EventDto> SelectByUserId(int userId);
    int InsertOne(EventDto dto);
    void UpdateById(int id, Action<EventDto> updateFunc);
    void DeleteById(int id);
}