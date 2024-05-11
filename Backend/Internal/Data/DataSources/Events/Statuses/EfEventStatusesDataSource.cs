using Hackaton_DW_2024.Internal.Data.Config;
using Hackaton_DW_2024.Internal.Data.Dto.Events;
using Hackaton_DW_2024.Internal.Data.Package;
using Microsoft.EntityFrameworkCore;
using ILogger = Hackaton_DW_2024.Infrastructure.Logging.ILogger;

namespace Hackaton_DW_2024.Internal.Data.DataSources.Events.Statuses;

public class EfEventStatusesDataSource : EntityFrameworkDataSource, IEventStatusesDataSource
{
    DbSet<EventStatusDto> _statuses;

    public EfEventStatusesDataSource(DatabaseConnectionConfig config, ILogger logger) : base(config, logger)
    {
    }

    public IEnumerable<EventStatusDto> SelectAll() => _statuses.ToList();

    public EventStatusDto? SelectById(int id) => _statuses.FirstOrDefault(dto => dto.Id == id);
}