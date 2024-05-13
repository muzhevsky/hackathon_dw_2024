using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Events.Results;

public class EfEventResultDataSource: EntityFrameworkDataSource, IEventResultsDataSource
{
    DbSet<EventResultDto> _eventResults;
    public EfEventResultDataSource(ApplicationContext context) : base(context)
    {
        _eventResults = context.EventResults;
    }

    public EventResultDto? SelectById(int id)
    {
        return _eventResults.FirstOrDefault(dto => dto.Id == id);
    }

    public IEnumerable<EventResultDto> SelectAll()
    {
        return _eventResults.ToList();
    }
}