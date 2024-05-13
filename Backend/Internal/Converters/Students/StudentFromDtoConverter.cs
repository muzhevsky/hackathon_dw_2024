using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities.Users;

namespace Hackaton_DW_2024.Internal.Converters.Students;

public class StudentDtoConverter: IConverter<Student, StudentDto>
{
    public StudentDto Convert(Student convertable)
    {
        return new StudentDto
        {
            GroupId = convertable.GroupId,
            StudentId = convertable.StudentId,
            Telegram = convertable.Telegram,
            PhoneNumber =convertable.PhoneNumber,
            UserId = convertable.UserId
        };
    }

    public Student ConvertBack(StudentDto convertable)
    {
        return new Student
        {
            UserId = convertable.UserId,
            GroupId = convertable.GroupId,
            StudentId = convertable.StudentId,
            Telegram = convertable.Telegram,
            PhoneNumber = convertable.PhoneNumber,
            Id = convertable.Id
        };
    }
}