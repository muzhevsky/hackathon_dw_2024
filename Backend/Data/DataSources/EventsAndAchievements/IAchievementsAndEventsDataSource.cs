using Hackaton_DW_2024.Data.Dto.Achievements;

namespace Hackaton_DW_2024.Data.DataSources.EventsAndAchievements;

public interface IAchievementsAndEventsDataSource
{
    IEnumerable<AchievementsAndEventsDto> SelectByEventId(int id);
    IEnumerable<AchievementsAndEventsDto> SelectByAchievementId(int id);
    void Insert(AchievementsAndEventsDto dto);
}