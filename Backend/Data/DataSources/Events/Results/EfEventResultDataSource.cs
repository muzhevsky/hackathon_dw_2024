using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Events.Results;

public class EfEventResultDataSource:  IEventResultsDataSource
{
    IDbContextFactory<ApplicationContext> _factory;
    public EfEventResultDataSource(IDbContextFactory<ApplicationContext>  context)
    {
        _factory = context;
    }

    public EventResultDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.EventResults.FirstOrDefault(dto => dto.Id == id);
    }

    public IEnumerable<EventResultDto> SelectAll()
    {
        using var context = _factory.CreateDbContext();
        return context.EventResults.ToList();
    }
}