using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.UseCases.Converters;

public class StudentConverter: IConverter<Student, StudentDto>
{
    IConverter<User, UserDto> _userConverter;

    public StudentConverter(IConverter<User, UserDto> userConverter)
    {
        _userConverter = userConverter;
    }

    public StudentDto Convert(Student convertable)
    {
        return new StudentDto
        {
            GroupId = convertable.Group.Id,
            StudentId = convertable.StudentId,
            Telegram = convertable.Telegram,
            User = _userConverter.Convert(convertable.UserData)
        };
    }
}