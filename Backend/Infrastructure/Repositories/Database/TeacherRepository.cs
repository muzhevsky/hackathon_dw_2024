using Hackaton_DW_2024.Data.DataSources.Groups;
using Hackaton_DW_2024.Data.DataSources.Students;
using Hackaton_DW_2024.Data.DataSources.Teachers;
using Hackaton_DW_2024.Data.DataSources.Users;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Internal.Converters;
using Hackaton_DW_2024.Internal.Entities.Users;

namespace Hackaton_DW_2024.Infrastructure.Repositories.Database;

public class TeacherRepository
{
    ITeacherDataSource _teacherDataSource;

    public TeacherRepository(ITeacherDataSource teacherDataSource)
    {
        _teacherDataSource = teacherDataSource;
    }

    public void CreateTeacher(TeacherDto teacher)
    {
        _teacherDataSource.Insert(teacher);
    }

    public TeacherDto? GetTeacherByUserId(int userId)
    {
        var dto = _teacherDataSource.SelectByUserId(userId);
        if (dto == null) return null;
        return dto;
    }
}