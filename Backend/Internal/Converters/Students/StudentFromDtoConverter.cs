using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities.Users;

namespace Hackaton_DW_2024.Internal.Converters.Students;

public class StudentFromDtoConverter: IConverter<StudentDto, Student>
{
    public Student Convert(StudentDto convertable)
    {
        return new Student
        {
            UserId = convertable.UserId,
            GroupId = convertable.GroupId,
            StudentId = convertable.StudentId,
            Telegram = convertable.Telegram,
        };
    }
}