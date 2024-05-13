using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.Converters.InstituteStructure;

public class DepartmentDtoConverter:IConverter<Department, DepartmentDto>
{
    public DepartmentDto Convert(Department convertable)
    {
        return new DepartmentDto
        {
            InstituteId = convertable.InstituteId,
            Title = convertable.Title,
            FullTitle = convertable.FullTitle
        };
    }

    public Department ConvertBack(DepartmentDto convertable)
    {
        return new Department
        {
            Id = convertable.Id,
            InstituteId = convertable.InstituteId,
            Title = convertable.Title,
            FullTitle = convertable.FullTitle
        };
    }
}