using Hackaton_DW_2024.Data.Converters;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Hackaton_DW_2024.Infrastructure.Repositories;
using Hackaton_DW_2024.Internal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.StudentsDS;

public class EfCreateStudentExecutor: ICommandExecutor<Student, int>
{
    IDbContextFactory<ApplicationContext> _contextFactory;
    IConverter<Student, EfStudentDto> _converter;

    public EfCreateStudentExecutor(
        IDbContextFactory<ApplicationContext> contextFactory, 
        IConverter<Student, EfStudentDto> converter
        )
    {
        _contextFactory = contextFactory;
        _converter = converter;
    }
    
    public int Execute(Student student)
    {
        using var context = _contextFactory.CreateDbContext();
        var dto = _converter.Convert(student);

        context.Students.Add(dto);
        context.SaveChanges();
        return dto.Id;
    }
}
