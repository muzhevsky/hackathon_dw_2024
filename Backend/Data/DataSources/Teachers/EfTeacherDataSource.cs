using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Teachers;

public class EfTeacherDataSource: EntityFrameworkDataSource, ITeacherDataSource
{
    DbSet<TeacherDto> Teachers { get; set; }
    public EfTeacherDataSource(ApplicationContext context) : base(context)
    {
        Teachers = context.Teachers;
    }

    public TeacherDto? SelectByUserId(int userId)
    {
        return Teachers.FirstOrDefault(dto => dto.UserId == userId);
    }

    public IEnumerable<TeacherDto> SelectByDepartmentId(int departmentId)
    {
        return Teachers.Where(dto => dto.DepartmentId == departmentId);
    }

    public void Insert(TeacherDto teacher)
    {
        Teachers.Add(teacher);
        Context.SaveChanges();
    }
}