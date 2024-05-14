using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Teachers;

public class EfTeacherDataSource:  ITeacherDataSource
{
    IDbContextFactory<ApplicationContext> _factory;
    public EfTeacherDataSource(IDbContextFactory<ApplicationContext>  context)
    {
        _factory = context;
    }

    public TeacherDto? SelectByUserId(int userId)
    {
        using var context = _factory.CreateDbContext();
        return context.Teachers.FirstOrDefault(dto => dto.UserId == userId);
    }

    public IEnumerable<TeacherDto> SelectByDepartmentId(int departmentId)
    {
        using var context = _factory.CreateDbContext();
        return context.Teachers.Where(dto => dto.DepartmentId == departmentId);
    }

    public void Insert(TeacherDto teacher)
    {
        using var context = _factory.CreateDbContext();
        context.Teachers.Add(teacher);
        context.SaveChanges();
    }
}