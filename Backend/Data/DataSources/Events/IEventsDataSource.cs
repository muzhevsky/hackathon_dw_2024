using Hackaton_DW_2024.Data.Dto;

namespace Hackaton_DW_2024.Data.DataSources.Events;

public interface IEventsDataSource
{
    EventDto SelectById(int id);
    IEnumerable<EventDto> SelectAll();
    IEnumerable<EventDto> SelectActive();
    IEnumerable<EventDto> SelectByNews(int newsId);
    IEnumerable<EventDto> SelectByStatusId(int statusId);
    // ... todo ещё подумать
    void InsertOne(EventDto dto);
    void UpdateById(int id, Action<EventDto> updateFunc);
    void DeleteById(int id);
}