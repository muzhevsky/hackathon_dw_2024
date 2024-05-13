using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Achievements;

public class EfCustomAchievementDataSource: EntityFrameworkDataSource, ICustomAchievementDataSource
{
    DbSet<CustomAchievementDto> _customAchievements;
    public EfCustomAchievementDataSource(ApplicationContext context) : base(context)
    {
        _customAchievements = context.CustomAchievements;
    }

    public CustomAchievementDto? SelectById(int id)
    {
        return _customAchievements.FirstOrDefault(dto => dto.Id == id);
    }

    public CustomAchievementDto? SelectByAchievementId(int id)
    {
        return _customAchievements.FirstOrDefault(dto => dto.AchievementId == id);
    }

    public void Insert(CustomAchievementDto dto)
    {
        _customAchievements.Add(dto);
        Context.SaveChanges();
    }
}