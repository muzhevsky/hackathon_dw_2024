using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;
using ILogger = Hackaton_DW_2024.Infrastructure.ILogger;

namespace Hackaton_DW_2024.Data.DataSources.NewsAndEvents;

public class EfNewsAndEventsDataSource : EntityFrameworkDataSource, INewsAndEventsDataSource
{
    DbSet<NewsAndEventsDto> NewsAndEvents { get; set; }

    public EfNewsAndEventsDataSource(DatabaseConnectionConfig config, ILogger logger) : base(config, logger)
    {
    }

    public IEnumerable<NewsAndEventsDto> SelectByNewsId(int newsId) =>
        NewsAndEvents.Where(dto => dto.NewsId == newsId);


    public IEnumerable<NewsAndEventsDto> SelectByEventId(int eventId) =>
        NewsAndEvents.Where(dto => dto.EventId == eventId);

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

        if (deleteTarget == null)
        {
            RaiseNotFoundError(NewsAndEventsDto.StructureName,
                new List<KeyValuePair<string, object>>
                {
                    new(nameof(NewsAndEventsDto.EventId), dto.EventId),
                    new(nameof(NewsAndEventsDto.NewsId), dto.NewsId),
                });
            return;
        }
        NewsAndEvents.Remove(deleteTarget);
        SaveChanges();
    }
}