using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Students;

public class EfStudentsDataSource:  IStudentsDataSource
{
    IDbContextFactory<ApplicationContext> _factory;

    public EfStudentsDataSource(IDbContextFactory<ApplicationContext>  context)
    {
        _factory = context;
    }

    public StudentDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.Students.FirstOrDefault(dto => dto.Id == id);
    }

    public StudentDto? SelectByUserId(int userId)
    {
        using var context = _factory.CreateDbContext();
        return context.Students.FirstOrDefault(dto => dto.UserId == userId);
    }

    public StudentDto? SelectByStudentId(string studentId)
    {
        using var context = _factory.CreateDbContext();
        return context.Students.FirstOrDefault(dto => dto.StudentId == studentId);
    }

    public int Insert(StudentDto dto)
    {
        using var context = _factory.CreateDbContext();
        context.Students.Add(dto);
        context.SaveChanges();
        return dto.Id;
    }

    public void UpdateByUserId(int userId, Action<StudentDto> updateFunc)
    {
        using var context = _factory.CreateDbContext();
        var updateTarget = SelectByUserId(userId);
        updateFunc(updateTarget);
        context.SaveChanges();
    }
}