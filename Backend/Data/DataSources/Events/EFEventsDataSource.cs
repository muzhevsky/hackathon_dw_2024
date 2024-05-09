using Hackaton_DW_2024.Data.Dto;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Events;

public class EFEventsDataSource: EntityFrameworkDataSource, IEventsDataSource
{
    DbSet<EventDto> Events { get; set; }
    DbSet<NewsAndEvents> NewsAndEvents { get; set; }
    public EFEventsDataSource(DatabaseConnectionConfig config) : base(config)
    {
    }

    public EventDto SelectById(int id)
    {
        return Events.FirstOrDefault(dto => dto.Id == id);
    }

    public IEnumerable<EventDto> SelectAll()
    {
        return Events.ToList();
    }

    public IEnumerable<EventDto> SelectActive()
    {
        return Events.Where(dto => dto.StartDate < DateTime.Now && dto.EndDate > DateTime.Now);
    }

    public IEnumerable<EventDto> SelectByNews(int newsId)
    {
        var newsAndEvents = NewsAndEvents.Where(record => record.NewsId == newsId).ToList();
        var result = new List<EventDto>();
        foreach (var record in newsAndEvents)
        {
            result.AddRange(Events.Where(dto => dto.Id == record.EventId));
        }

        return result;
    }

    public IEnumerable<EventDto> SelectByStatusId(int statusId)
    {
        return Events.Where(dto => dto.StatusId == statusId);
    }

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