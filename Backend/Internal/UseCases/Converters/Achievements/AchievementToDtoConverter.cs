using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.UseCases.Converters.Achievements;

public class AchievementToDtoConverter: IConverter<Achievement, AchievementDto>
{
    public AchievementDto Convert(Achievement convertable)
    {
        return new AchievementDto();
    }
}