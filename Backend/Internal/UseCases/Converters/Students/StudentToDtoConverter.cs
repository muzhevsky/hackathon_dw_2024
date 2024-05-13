using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.UseCases.Converters.Students;

public class StudentToDtoConverter: IConverter<Student, StudentDto>
{
    IConverter<Entities.User, UserDto> _userConverter;

    public StudentToDtoConverter(IConverter<Entities.User, UserDto> userConverter)
    {
        _userConverter = userConverter;
    }

    public StudentDto Convert(Student convertable)
    {
        return new StudentDto
        {
            GroupId = convertable.GroupId,
            StudentId = convertable.StudentId,
            Telegram = convertable.Telegram,
            UserId = convertable.UserId
        };
    }
}