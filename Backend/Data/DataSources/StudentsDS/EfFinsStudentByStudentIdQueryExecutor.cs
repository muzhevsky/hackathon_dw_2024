using Hackaton_DW_2024.Data.Converters;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Hackaton_DW_2024.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.StudentsDS;

public class EfFindStudentByStudentIdQueryExecutor: ICommandExecutor<StudentByStudentIdQuery, Internal.Entities.Student>
{
    IDbContextFactory<ApplicationContext> _contextFactory;
    IConverter<EfStudentDto, Internal.Entities.Student> _converter;

    public EfFindStudentByStudentIdQueryExecutor(IDbContextFactory<ApplicationContext> contextFactory, IConverter<EfStudentDto, Internal.Entities.Student> converter)
    {
        _contextFactory = contextFactory;
        _converter = converter;
    }

    public Internal.Entities.Student? Execute(StudentByStudentIdQuery query)
    {
        using var context = _contextFactory.CreateDbContext();
        var dto = context.Students.FirstOrDefault(d => d.StudentId == query.StudentId);

        if (dto == null) return null;

        return _converter.Convert(dto);
    }
}
