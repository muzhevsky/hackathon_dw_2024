using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.EventsAndAchievements;

public class EfAchievementsAndEventsDataSource: EntityFrameworkDataSource, IAchievementsAndEventsDataSource
{
    DbSet<AchievementsAndEventsDto> _achievementsAndEvents;
    public EfAchievementsAndEventsDataSource(ApplicationContext context) : base(context)
    {
        _achievementsAndEvents = context.AchievementsAndEvents;
    }

    public IEnumerable<AchievementsAndEventsDto> SelectByEventId(int id)
    {
        return _achievementsAndEvents.Where(dto => dto.EventId == id);
    }

    public IEnumerable<AchievementsAndEventsDto> SelectByAchievementId(int id)
    {
        return _achievementsAndEvents.Where(dto => dto.AchievementId == id);
    }

    public void Insert(AchievementsAndEventsDto dto)
    {
        _achievementsAndEvents.Add(dto);
        Context.SaveChanges();
    }
}