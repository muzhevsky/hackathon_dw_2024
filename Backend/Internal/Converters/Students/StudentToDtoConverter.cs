using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities.Users;

namespace Hackaton_DW_2024.Internal.Converters.Students;

public class StudentToDtoConverter: IConverter<Student, StudentDto>
{
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