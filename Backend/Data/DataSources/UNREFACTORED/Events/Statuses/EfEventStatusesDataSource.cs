using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Events.Statuses;

public class EfEventStatusesDataSource :  IEventStatusesDataSource
{
    IDbContextFactory<ApplicationContext> _factory;

    public EfEventStatusesDataSource(IDbContextFactory<ApplicationContext>  context)
    {
        _factory = context;
    }

    public IEnumerable<EventStatusDto> SelectAll()
    {
        using var context = _factory.CreateDbContext();
        return context.EventStatuses.ToList();
    }

    public EventStatusDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.EventStatuses.FirstOrDefault(dto => dto.Id == id);
    }
}