using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Students;

public class EfStudentsDataSource: EntityFrameworkDataSource, IStudentsDataSource
{
    DbSet<StudentDto> Students { get; set; }
    DbSet<UserDto> Users { get; set; }

    public EfStudentsDataSource(ApplicationContext context) : base(context)
    {
        Students = context.Students;
    }

    public StudentDto? SelectById(int id)
    {
        return Students.FirstOrDefault(dto => dto.Id == id);
    }

    public StudentDto? SelectByUserId(int userId)
    {
        return Students.FirstOrDefault(dto => dto.UserId == userId);
    }

    public StudentDto? SelectByStudentId(string studentId)
    {
        return Students.FirstOrDefault(dto => dto.StudentId == studentId);
    }

    public int Insert(StudentDto dto)
    {
        Students.Add(dto);
        Context.SaveChanges();
        return dto.Id;
    }

    public void UpdateByUserId(int userId, Action<StudentDto> updateFunc)
    {
        var updateTarget = SelectByUserId(userId);
        updateFunc(updateTarget);
        Context.SaveChanges();
    }
}