using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.NewsAndEvents;

public class EfNewsAndEventsDataSource : EntityFrameworkDataSource, INewsAndEventsDataSource
{
    DbSet<NewsAndEventsDto> NewsAndEvents { get; set; }

    public EfNewsAndEventsDataSource(DatabaseConnectionConfig config) : base(config)
    {
    }

    public IEnumerable<NewsAndEventsDto> SelectByNewsId(int newsId) =>
        NewsAndEvents.Where(dto => dto.NewsId == newsId).ToList();


    public IEnumerable<NewsAndEventsDto> SelectByEventId(int eventId) =>
        NewsAndEvents.Where(dto => dto.EventId == eventId).ToList();

    public void Insert(NewsAndEventsDto dto)
    {
        NewsAndEvents.Add(dto);
        SaveChanges();
    }

    public void Delete(NewsAndEventsDto dto)
    {
        var deleteTarget = NewsAndEvents.FirstOrDefault(
            record =>
                record.EventId == dto.EventId &&
                record.NewsId == dto.NewsId
        );

        if (deleteTarget == null) throw new Exception("no entity found");
        NewsAndEvents.Remove(deleteTarget);
        SaveChanges();
    }
}