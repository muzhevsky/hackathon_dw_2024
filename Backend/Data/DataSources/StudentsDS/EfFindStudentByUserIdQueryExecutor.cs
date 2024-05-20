using Hackaton_DW_2024.Data.Converters;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Hackaton_DW_2024.Infrastructure.Repositories;
using Hackaton_DW_2024.Internal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.StudentsDS;

public class EfFindStudentByUserIdQueryExecutor: ICommandExecutor<StudentByUserIdQuery, Student>
{
    IDbContextFactory<ApplicationContext> _contextFactory;
    IConverter<EfStudentDto, Student> _converter;

    public EfFindStudentByUserIdQueryExecutor(IDbContextFactory<ApplicationContext> contextFactory, IConverter<EfStudentDto, Student> converter)
    {
        _contextFactory = contextFactory;
        _converter = converter;
    }

    public Student? Execute(StudentByUserIdQuery query)
    {
        using var context = _contextFactory.CreateDbContext();
        var dto = context.Students.FirstOrDefault(d => d.UserId == query.UserId);

        if (dto == null) return null;

        return _converter.Convert(dto);
    }
}