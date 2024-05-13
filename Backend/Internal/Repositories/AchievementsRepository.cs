using Hackaton_DW_2024.Data.DataSources.Achievements;
using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.UseCases.Converters;

namespace Hackaton_DW_2024.Internal.Repositories;

public class AchievementsRepository
{
    IAchievementsDataSource _achievementsDataSource;
    IConverter<Achievement, AchievementDto> _achievementConverter;
    IConverter<AchievementDto, Achievement> _achievementDtoConverter;

    public AchievementsRepository(
        IAchievementsDataSource achievementsDataSource, 
        IConverter<AchievementDto, Achievement> achievementDtoConverter, 
        IConverter<Achievement, AchievementDto> achievementConverter)
    {
        _achievementsDataSource = achievementsDataSource;
        _achievementDtoConverter = achievementDtoConverter;
        _achievementConverter = achievementConverter;
    }

    public List<Achievement> AchievementsOfStudent(Student student)
    {
        var result = new List<Achievement>();
        foreach (var achievement in _achievementsDataSource.SelectByUserId(student.UserId))
        {
            Console.WriteLine($"achievement: {achievement.Id}");
            result.Add(_achievementDtoConverter.Convert(achievement));
        }
        return result;
    }

    public void AddAchievement(Achievement achievement)
    {
        _achievementsDataSource.Insert(_achievementConverter.Convert(achievement));
    }
}