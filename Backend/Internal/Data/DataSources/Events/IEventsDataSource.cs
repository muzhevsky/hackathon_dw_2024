using Hackaton_DW_2024.Internal.Data.Dto.Events;

namespace Hackaton_DW_2024.Internal.Data.DataSources.Events;

public interface IEventsDataSource
{
    EventDto SelectById(int id);
    IEnumerable<EventDto> SelectAll();
    IEnumerable<EventDto> SelectActive();
    IEnumerable<EventDto> SelectByStatusId(int statusId);
    void InsertOne(EventDto dto);
    void UpdateById(int id, Action<EventDto> updateFunc);
    void DeleteById(int id);
}