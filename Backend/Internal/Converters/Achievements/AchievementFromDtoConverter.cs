using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.Converters.Achievements;

public class AchievementDtoConverter: IConverter<Achievement, AchievementDto>
{
    public AchievementDto Convert(Achievement convertable)
    {
        return new AchievementDto
        {
            Score = convertable.Score,
            UserId = convertable.UserId,
            WithTeam = convertable.WithTeam,
        };
    }

    public Achievement ConvertBack(AchievementDto convertable)
    {
        return new Achievement
        {
            Id = convertable.Id,
            Score = convertable.Score,
            WithTeam = convertable.WithTeam,
            UserId = convertable.UserId
        };
    }
}