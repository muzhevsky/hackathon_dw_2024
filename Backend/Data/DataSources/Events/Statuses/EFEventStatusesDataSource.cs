using Hackaton_DW_2024.Data.Dto;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Events.Statuses;

public class EFEventStatusesDataSource: DbContext, IEventStatusesDataSource
{
    DbSet<EventStatusDto> Statuses; 
    public IEnumerable<EventStatusDto> SelectAll()
    {
        return Statuses.ToList();
    }

    public EventStatusDto? SelectById(int id)
    {
        return Statuses.FirstOrDefault(dto => dto.Id == id);
    }
}