using Hackaton_DW_2024.Internal.Data.Dto.Events;

namespace Hackaton_DW_2024.Internal.Data.DataSources.NewsAndEvents;

public interface INewsAndEventsDataSource
{
    IEnumerable<NewsAndEventsDto> SelectByNewsId(int newsId);
    IEnumerable<NewsAndEventsDto> SelectByEventId(int eventId);
    void Insert(NewsAndEventsDto dto);
    void Delete(NewsAndEventsDto dto);
}