using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Events;

public class EfEventsDataSource : EntityFrameworkDataSource, IEventsDataSource
{
    DbSet<EventDto> _events;
    DbSet<UsersAndEventsDto> _usersAndEvents;

    public EfEventsDataSource(ApplicationContext context) : base(context)
    {
        _usersAndEvents = context.UsersAndEvents;
        _events = context.Events;
    }

    public EventDto? SelectById(int id)
    {
        return _events.FirstOrDefault(dto => dto.Id == id);
    }

    public IEnumerable<EventDto> SelectAll() => _events.ToList();

    public IEnumerable<EventDto> SelectActive() =>
        _events.Where(dto => dto.StartDate < DateTime.Now && dto.EndDate > DateTime.Now);

    public IEnumerable<EventDto> SelectByStatusId(int statusId) =>
        _events.Where(dto => dto.StatusId == statusId);

    public IEnumerable<EventDto> SelectByUserId(int userId)
    {
        var usersAndEvents = _usersAndEvents.Where(dto => dto.UserId == userId);
        var result = new List<EventDto>();
        foreach (var ue in usersAndEvents)
        {
            result.AddRange(_events.Where(dto => dto.Id == ue.EventId));
        }

        return result;
    }

    public int InsertOne(EventDto dto)
    {
        _events.Add(dto);
        Context.SaveChanges();
        return dto.Id;
    }

    public void UpdateById(int id, Action<EventDto> updateFunc)
    {
        var updateTarget = _events.FirstOrDefault(dto => dto.Id == id);
        updateFunc(updateTarget);
        Context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var deleteTarget = _events.FirstOrDefault(dto => dto.Id == id);
        _events.Remove(deleteTarget);
        Context.SaveChanges();
    }
}