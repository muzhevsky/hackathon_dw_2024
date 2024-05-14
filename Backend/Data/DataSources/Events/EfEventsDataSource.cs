using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Events;

public class EfEventsDataSource : IEventsDataSource
{
    IDbContextFactory<ApplicationContext> _factory;

    public EfEventsDataSource(IDbContextFactory<ApplicationContext> context)
    {
        _factory = context;
    }

    public EventDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.Events.FirstOrDefault(dto => dto.Id == id);
    }

    public IEnumerable<EventDto> SelectAll()
    {
        using var context = _factory.CreateDbContext();
        return context.Events.ToList();
    }

    public IEnumerable<EventDto> SelectActive()
    {
        using var context = _factory.CreateDbContext();
        return context.Events.Where(dto => dto.StartDate < DateTime.Now && dto.EndDate > DateTime.Now);
    }

    public IEnumerable<EventDto> SelectByStatusId(int statusId)
    {
        using var context = _factory.CreateDbContext();
        return context.Events.Where(dto => dto.StatusId == statusId);
        
    }

    public IEnumerable<EventDto> SelectByUserId(int userId)
    {
        using var context = _factory.CreateDbContext();
        var usersAndEvents = context.UsersAndEvents.Where(dto => dto.UserId == userId);
        var result = new List<EventDto>();
        foreach (var ue in usersAndEvents)
        {
            result.AddRange(context.Events.Where(dto => dto.Id == ue.EventId));
        }

        return result;
    }

    public int InsertOne(EventDto dto)
    {
        using var context = _factory.CreateDbContext();
        context.Events.Add(dto);
        context.SaveChanges();
        return dto.Id;
    }

    public void UpdateById(int id, Action<EventDto> updateFunc)
    {
        using var context = _factory.CreateDbContext();
        var updateTarget = context.Events.FirstOrDefault(dto => dto.Id == id);
        updateFunc(updateTarget);
        context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        using var context = _factory.CreateDbContext();
        var deleteTarget = context.Events.FirstOrDefault(dto => dto.Id == id);
        context.Events.Remove(deleteTarget);
        context.SaveChanges();
    }
}