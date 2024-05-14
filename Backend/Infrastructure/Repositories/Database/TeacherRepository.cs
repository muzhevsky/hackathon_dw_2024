using Hackaton_DW_2024.Data.DataSources.Teachers;
using Hackaton_DW_2024.Data.Dto.Users;

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