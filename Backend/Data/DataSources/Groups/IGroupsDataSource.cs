using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;

namespace Hackaton_DW_2024.Data.DataSources.Groups;

public interface IGroupsDataSource
{
    GroupDto? SelectById(int id);
    IEnumerable<GroupDto> SelectAll();
    IEnumerable<GroupDto> SelectByDepartmentId(int departmentId);
    void Insert(GroupDto dto);
}