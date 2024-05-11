using Hackaton_DW_2024.Internal.Data.Dto.Achievements;

namespace Hackaton_DW_2024.Internal.Data.DataSources.Achievements;

public interface IAchievementsDataSource
{
    AchievementDto? SelectById(int id);
    IEnumerable<AchievementDto> SelectByUserId(int userId);
    void Insert(AchievementDto achievement);
    void UpdateById(int id, Action<AchievementDto> updateFunc);
    void DeleteById(int id);
}