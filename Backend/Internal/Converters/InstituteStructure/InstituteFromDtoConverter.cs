using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.Converters.InstituteStructure;

public class InstituteDtoConverter: IConverter<Institute, InstituteDto>
{
    public InstituteDto Convert(Institute convertable)
    {
        return new InstituteDto
        {
            Title = convertable.Title,
            FullTitle = convertable.FullTitle
        };
    }

    public Institute ConvertBack(InstituteDto convertable)
    {
        return new Institute
        {
            Id = convertable.Id,
            Title = convertable.Title,
            FullTitle = convertable.FullTitle
        };
    }
}