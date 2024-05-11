using Hackaton_DW_2024.Internal.Data.Dto.Events;

namespace Hackaton_DW_2024.Internal.Data.DataSources.News;

public interface INewsDataSource
{
    NewsDto? SelectById(int id);
    IEnumerable<NewsDto> SelectAll();
    IEnumerable<NewsDto> SelectPinned();
    IEnumerable<NewsDto> SelectRangeWithOffsetByDate(int range, int offset, bool ascending);
    void Insert(NewsDto news);
    void UpdateById(int id, Action<NewsDto> updateFunc);
    void DeleteById(int id);
}