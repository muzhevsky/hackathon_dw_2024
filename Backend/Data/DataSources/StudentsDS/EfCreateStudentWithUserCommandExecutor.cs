using Hackaton_DW_2024.Data.Converters;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Hackaton_DW_2024.Infrastructure.Repositories;
using Hackaton_DW_2024.Internal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.StudentsDS;

public class EfCreateStudentCommandExecutor : ICommandExecutor<CreateStudentCommand, int>
{
    IDbContextFactory<ApplicationContext> _contextFactory;
    IConverter<Student, EfStudentDto> _studentConverter;
    IConverter<User, EfUserDto> _userConverter;

    public EfCreateStudentCommandExecutor(
        IDbContextFactory<ApplicationContext> contextFactory,
        IConverter<Student, EfStudentDto> studentConverter,
        IConverter<User, EfUserDto> userConverter)
    {
        _contextFactory = contextFactory;
        _studentConverter = studentConverter;
        _userConverter = userConverter;
    }

    public int Execute(CreateStudentCommand command)
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            var userDto = _userConverter.Convert(command.User);
            var studentDto = _studentConverter.Convert(command.Student);

            studentDto.User = userDto;

            context.Students.Add(studentDto);
            context.SaveChanges();
            command.Student.UserId = userDto.Id;
            command.Student.Id = studentDto.Id;
            command.User.Id = userDto.Id;
        }

        return command.Student.Id;
    }
}