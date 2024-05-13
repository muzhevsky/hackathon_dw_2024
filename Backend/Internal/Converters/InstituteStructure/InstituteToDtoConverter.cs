using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.Converters.InstituteStructure;

public class InstituteToDtoConverter: IConverter<Institute, InstituteDto>
{
    public InstituteDto Convert(Institute convertable)
    {
        return new InstituteDto
        {
            Id = convertable.Id,
            Title = convertable.Title
        };
    }
}