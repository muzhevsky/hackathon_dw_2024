using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.UseCases.Converters.Students;

public class StudentFromDtoConverter: IConverter<StudentDto, Student>
{
    IConverter<UserDto, Entities.User> _usersFromDtoConverter;

    public StudentFromDtoConverter(IConverter<UserDto, Entities.User> usersFromDtoConverter)
    {
        _usersFromDtoConverter = usersFromDtoConverter;
    }

    public Student Convert(StudentDto convertable)
    {
        return new Student
        {
            UserId = convertable.UserId,
            Group = convertable.Group.Title,
            StudentId = convertable.StudentId,
            Telegram = convertable.Telegram
        };
    }
}