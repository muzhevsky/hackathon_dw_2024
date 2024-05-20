using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Data.Converters.Teachers;

public class TeacherFromEfDtoConverter: IConverter<EfTeacherDto, Teacher>
{
    public Teacher Convert(EfTeacherDto convertable)
    {
        return new Teacher
        {
            UserId = convertable.UserId,
            Id = convertable.Id,
            DepartmentId = convertable.DepartmentId
        };
    }
}