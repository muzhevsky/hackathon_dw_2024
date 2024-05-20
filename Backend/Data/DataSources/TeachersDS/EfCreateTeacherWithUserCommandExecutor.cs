using Hackaton_DW_2024.Data.Converters;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Hackaton_DW_2024.Infrastructure.Repositories;
using Hackaton_DW_2024.Internal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.TeachersDS;

public class EfCreateTeacherWithUserCommandExecutor : ICommandExecutor<CreateTeacherWithUserCommand, int>
{
    IDbContextFactory<ApplicationContext> _contextFactory;
    IConverter<Teacher, EfTeacherDto> _teacherConverter;
    IConverter<User, EfUserDto> _userConverter;

    public EfCreateTeacherWithUserCommandExecutor(
        IDbContextFactory<ApplicationContext> contextFactory,
        IConverter<Teacher, EfTeacherDto> teacherConverter,
        IConverter<User, EfUserDto> userConverter)
    {
        _contextFactory = contextFactory;
        _teacherConverter = teacherConverter;
        _userConverter = userConverter;
    }

    public int Execute(CreateTeacherWithUserCommand command)
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            var userDto = _userConverter.Convert(command.User);
            var teacherDto = _teacherConverter.Convert(command.Teacher);

            teacherDto.User = userDto;
            
            context.Teachers.Add(teacherDto);
            context.SaveChanges();
            command.User.Id = userDto.Id;
            command.Teacher.Id = teacherDto.Id;
            command.Teacher.UserId = userDto.Id;
        }

        return command.Teacher.Id;
    }
}