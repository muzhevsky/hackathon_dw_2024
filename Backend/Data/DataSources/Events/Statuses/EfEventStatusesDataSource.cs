using Hackaton_DW_2024.Data.Config;
using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Events.Statuses;

public class EfEventStatusesDataSource : EntityFrameworkDataSource, IEventStatusesDataSource
{
    DbSet<EventStatusDto> _statuses { get; set; }

    public EfEventStatusesDataSource(ApplicationContext context) : base(context)
    {
        _statuses = context.EventStatuses;
    }

    public IEnumerable<EventStatusDto> SelectAll() => _statuses.ToList();

    public EventStatusDto? SelectById(int id) => _statuses.FirstOrDefault(dto => dto.Id == id);
}