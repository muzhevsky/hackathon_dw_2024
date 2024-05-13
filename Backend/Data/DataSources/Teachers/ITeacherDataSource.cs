using Hackaton_DW_2024.Data.Dto.Users;

namespace Hackaton_DW_2024.Data.DataSources.Teachers;

public interface ITeacherDataSource
{
    TeacherDto? SelectByUserId(int userId);
    IEnumerable<TeacherDto> SelectByDepartmentId(int departmentId);
    void Insert(TeacherDto teacher);
}