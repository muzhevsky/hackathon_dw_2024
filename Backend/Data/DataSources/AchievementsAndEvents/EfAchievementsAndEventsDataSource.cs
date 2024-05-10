using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;
using ILogger = Hackaton_DW_2024.Infrastructure.ILogger;

namespace Hackaton_DW_2024.Data.DataSources.AchievementsAndEvents;

public class EfAchievementsAndEventsDataSource : EntityFrameworkDataSource, IAchievementsAndEventsDataSource
{
    DbSet<AchievementsAndEventsDto> _achievementsAndEvents;

    public EfAchievementsAndEventsDataSource(DatabaseConnectionConfig config, ILogger logger) : base(config, logger)
    {
    }

    public IEnumerable<AchievementsAndEventsDto> SelectByEventId(int eventId) =>
        _achievementsAndEvents.Where(dto => dto.EventId == eventId);

    public IEnumerable<AchievementsAndEventsDto> SelectByAchievementId(int achievementId) =>
        _achievementsAndEvents.Where(dto => dto.AchievementId == achievementId);

    public void Insert(AchievementsAndEventsDto dto)
    {
        _achievementsAndEvents.Add(dto);
        SaveChanges();
    }

    public void Delete(AchievementsAndEventsDto dto)
    {
        var deleteTarget = _achievementsAndEvents.FirstOrDefault(
            eventsDto =>
                eventsDto.EventId == dto.EventId &&
                eventsDto.AchievementId == dto.AchievementId
        );
        if (deleteTarget == null)
        {
            RaiseNotFoundError(AchievementDto.StructureName,
                new List<KeyValuePair<string, object>>
                {
                    new(nameof(AchievementsAndEventsDto.EventId), dto.EventId),
                    new(nameof(AchievementsAndEventsDto.AchievementId), dto.AchievementId),
                });
            return;
        }

        _achievementsAndEvents.Remove(deleteTarget);
        SaveChanges();
    }
}