using Hackaton_DW_2024.Data.Dto;

namespace Hackaton_DW_2024.Data.DataSources.News;

public interface INewsDataSource
{
    NewsDto? SelectById(int id);
    List<NewsDto> SelectAll();
    List<NewsDto> SelectPinned();
    List<NewsDto> SelectRangeWithOffsetByDate(int range, int offset, bool ascending);
    List<NewsDto> SelectByConnectedEvent(int eventId);
    void Insert(NewsDto news);
    void UpdateById(int id, Action<NewsDto> updateFunc);
    void DeleteById(int id);
}