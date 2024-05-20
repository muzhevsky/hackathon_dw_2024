using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Departments;

public interface IDepartmentsDataSource
{
    DepartmentDto? SelectById(int id);
    IEnumerable<DepartmentDto> SelectAll();
    IEnumerable<DepartmentDto> SelectByInstituteId(int instituteId);
}