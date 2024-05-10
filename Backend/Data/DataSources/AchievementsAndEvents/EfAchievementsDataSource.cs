using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.AchievementsAndEvents;

public class EfAchievementsAndEventsDataSource : EntityFrameworkDataSource, IAchievementsAndEventsDataSource
{
    DbSet<AchievementsAndEventsDto> _achievementsAndEvents;

    public EfAchievementsAndEventsDataSource(DatabaseConnectionConfig config) : base(config)
    {
    }

    public IEnumerable<AchievementsAndEventsDto> SelectByEventId(int eventId) =>
        _achievementsAndEvents.Where(dto => dto.EventId == eventId).ToList();

    public IEnumerable<AchievementsAndEventsDto> SelectByAchievementId(int achievementId) =>
        _achievementsAndEvents.Where(dto => dto.AchievementId == achievementId).ToList();

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
        if (deleteTarget == null) throw new Exception("no entity found");
        _achievementsAndEvents.Remove(deleteTarget);
        SaveChanges();
    }
}