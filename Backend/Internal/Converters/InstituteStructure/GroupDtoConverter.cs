using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.Converters.InstituteStructure;

public class GroupDtoConverter:IConverter<Group, GroupDto>
{
    public GroupDto Convert(Group convertable)
    {
        return new GroupDto
        {
            Title = convertable.Title,
            DepartmentId = convertable.DepartmentId,
            SpecialityId = convertable.SpecialityId
        };
    }

    public Group ConvertBack(GroupDto convertable)
    {
        return new Group
        {
            Id = convertable.Id,
            Title = convertable.Title,
            DepartmentId = convertable.DepartmentId,
            SpecialityId = convertable.SpecialityId
        };
    }
}