using Hackaton_DW_2024.Data.Dto;

namespace Hackaton_DW_2024.Data.DataSources.Achievements;

public interface IAchievementsDataSource
{
    IEnumerable<AchievementDto> SelectByUserId(int id);
    AchievementDto? SelectById(int id);
    void Insert(AchievementDto achievement);
    void UpdateById(int id, Action<AchievementDto> updateFunc);
    void DeleteById(int id);
}