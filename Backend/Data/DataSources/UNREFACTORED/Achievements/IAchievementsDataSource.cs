using Hackaton_DW_2024.Data.Dto.Achievements;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Achievements;

public interface IAchievementsDataSource
{
    AchievementDto? SelectById(int id);
    IEnumerable<AchievementDto> SelectByUserId(int userId);
    int Insert(AchievementDto achievement);
    void UpdateById(int id, Action<AchievementDto> updateFunc);
    void DeleteById(int id);
}