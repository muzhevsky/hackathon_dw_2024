using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Data.Converters.Students;

public class StudentFromEfDtoConverter: IConverter<EfStudentDto, Student>
{
    public Student Convert(EfStudentDto convertable)
    {
        return new Student()
        {
            UserId = convertable.UserId,
            PhoneNumber = convertable.PhoneNumber,
            StudentId = convertable.StudentId,
            GroupId = convertable.GroupId,
            Telegram = convertable.Telegram
        };
    }
}