using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Events.Statuses;

public class EfEventStatusesDataSource : EntityFrameworkDataSource, IEventStatusesDataSource
{
    DbSet<EventStatusDto> _statuses;

    public EfEventStatusesDataSource(DatabaseConnectionConfig config, Infrastructure.ILogger logger) : base(config, logger)
    {
    }

    public IEnumerable<EventStatusDto> SelectAll() => _statuses.ToList();

    public EventStatusDto? SelectById(int id) => _statuses.FirstOrDefault(dto => dto.Id == id);
}