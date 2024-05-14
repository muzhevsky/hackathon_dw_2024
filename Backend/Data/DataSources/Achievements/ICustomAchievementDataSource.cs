using Hackaton_DW_2024.Data.Dto.Achievements;

namespace Hackaton_DW_2024.Data.DataSources.Achievements;

public interface ICustomAchievementDataSource
{
    CustomAchievementDto? SelectById(int id);
    CustomAchievementDto? SelectByAchievementId(int id);
    void Insert(CustomAchievementDto dto);
    void RemoveById(int id);
}