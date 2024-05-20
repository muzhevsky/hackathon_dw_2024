using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Students;

public class EfStudentsDataSource:  IStudentsDataSource
{
    IDbContextFactory<ApplicationContext> _factory;

    public EfStudentsDataSource(IDbContextFactory<ApplicationContext>  context)
    {
        _factory = context;
    }

    public EfStudentDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.Students.FirstOrDefault(dto => dto.Id == id);
    }

    public EfStudentDto? SelectByUserId(int userId)
    {
        using var context = _factory.CreateDbContext();
        return context.Students.FirstOrDefault(dto => dto.UserId == userId);
    }

    public EfStudentDto? SelectByStudentId(string studentId)
    {
        using var context = _factory.CreateDbContext();
        return context.Students.FirstOrDefault(dto => dto.StudentId == studentId);
    }

    public int Insert(EfStudentDto dto)
    {
        using var context = _factory.CreateDbContext();
        context.Students.Add(dto);
        context.SaveChanges();
        return dto.Id;
    }

    public void UpdateByUserId(int userId, Action<EfStudentDto> updateFunc)
    {
        using var context = _factory.CreateDbContext();
        var updateTarget = SelectByUserId(userId);
        updateFunc(updateTarget);
        context.SaveChanges();
    }
}