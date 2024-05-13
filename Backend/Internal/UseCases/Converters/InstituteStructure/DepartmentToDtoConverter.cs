using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.UseCases.Converters.InstituteStructure;

public class DepartmentToDtoConverter: IConverter<Department, DepartmentDto>
{
    IConverter<Institute, InstituteDto> _instituteConverter;

    public DepartmentToDtoConverter(IConverter<Institute, InstituteDto> instituteConverter)
    {
        _instituteConverter = instituteConverter;
    }

    public DepartmentDto Convert(Department convertable)
    {
        return new DepartmentDto
        {
            Id = convertable.Id,
            InstituteId = convertable.InstituteId,
            Title = convertable.Title,
        };
    }
}