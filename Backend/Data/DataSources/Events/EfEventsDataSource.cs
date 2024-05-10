using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Events;

public class EfEventsDataSource : EntityFrameworkDataSource, IEventsDataSource
{
    DbSet<EventDto> Events { get; set; }

    public EfEventsDataSource(DatabaseConnectionConfig config) : base(config)
    {
    }

    public EventDto SelectById(int id) => Events.FirstOrDefault(dto => dto.Id == id);

    public IEnumerable<EventDto> SelectAll() => Events.ToList();

    public IEnumerable<EventDto> SelectActive() =>
        Events.Where(dto => dto.StartDate < DateTime.Now && dto.EndDate > DateTime.Now).ToList();

    public IEnumerable<EventDto> SelectByStatusId(int statusId) =>
        Events.Where(dto => dto.StatusId == statusId).ToList();

    public void InsertOne(EventDto dto)
    {
        Events.Add(dto);
        SaveChanges();
    }

    public void UpdateById(int id, Action<EventDto> updateFunc)
    {
        var updateTarget = Events.FirstOrDefault(dto => dto.Id == id);
        if (updateTarget == null) throw new Exception("no entity found");
        updateFunc(updateTarget);
        SaveChanges();
    }

    public void DeleteById(int id)
    {
        var deleteTarget = Events.FirstOrDefault(dto => dto.Id == id);
        if (deleteTarget == null) throw new Exception("no entity found");
        Events.Remove(deleteTarget);
        SaveChanges();
    }
}