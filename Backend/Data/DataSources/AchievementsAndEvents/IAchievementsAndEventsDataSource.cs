using Hackaton_DW_2024.Data.Dto.Achievements;

namespace Hackaton_DW_2024.Data.DataSources.AchievementsAndEvents;

public interface IAchievementsAndEventsDataSource
{
    IEnumerable<AchievementsAndEventsDto> SelectByEventId(int eventId);
    IEnumerable<AchievementsAndEventsDto> SelectByAchievementId(int achievementId);
    void Insert(AchievementsAndEventsDto dto);
    void Delete(AchievementsAndEventsDto dto);
}