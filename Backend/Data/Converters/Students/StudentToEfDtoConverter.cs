using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Data.Converters.Students;

public class StudentToEfDtoConverter: IConverter<Student, EfStudentDto>
{
    public EfStudentDto Convert(Student convertable)
    {
        var dto = new EfStudentDto
        {
            StudentId = convertable.StudentId,
            UserId = convertable.UserId,
            GroupId = convertable.GroupId,
            Telegram = convertable.Telegram,
            PhoneNumber = convertable.PhoneNumber
        };

        return dto;
    }
}