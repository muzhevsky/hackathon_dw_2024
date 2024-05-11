using Hackaton_DW_2024.Internal.Data.Config;
using Hackaton_DW_2024.Internal.Data.Dto.Events;
using Hackaton_DW_2024.Internal.Data.Package;
using Microsoft.EntityFrameworkCore;
using ILogger = Hackaton_DW_2024.Infrastructure.Logging.ILogger;

namespace Hackaton_DW_2024.Internal.Data.DataSources.Events;

public class EfEventsDataSource : EntityFrameworkDataSource, IEventsDataSource
{
    DbSet<EventDto> Events { get; set; }

    public EfEventsDataSource(DatabaseConnectionConfig config, ILogger logger) : base(config, logger)
    {
    }

    public EventDto SelectById(int id) => Events.FirstOrDefault(dto => dto.Id == id);

    public IEnumerable<EventDto> SelectAll() => Events.ToList();

    public IEnumerable<EventDto> SelectActive() =>
        Events.Where(dto => dto.StartDate < DateTime.Now && dto.EndDate > DateTime.Now);

    public IEnumerable<EventDto> SelectByStatusId(int statusId) =>
        Events.Where(dto => dto.StatusId == statusId);

    public void InsertOne(EventDto dto)
    {
        Events.Add(dto);
        SaveChanges();
    }

    public void UpdateById(int id, Action<EventDto> updateFunc)
    {
        var updateTarget = Events.FirstOrDefault(dto => dto.Id == id);
        if (updateTarget == null)
        {
            RaiseNotFoundError(EventDto.StructureName,
                new List<KeyValuePair<string, object>>
                {
                    new(nameof(EventDto.Id), id)
                });
            return;
        }
        updateFunc(updateTarget);
        SaveChanges();
    }

    public void DeleteById(int id)
    {
        var deleteTarget = Events.FirstOrDefault(dto => dto.Id == id);
        if (deleteTarget == null) 
        {
            RaiseNotFoundError(EventDto.StructureName,
                new List<KeyValuePair<string, object>>
                {
                    new(nameof(EventDto.Id), id)
                });
            return;
        }
        Events.Remove(deleteTarget);
        SaveChanges();
    }
}