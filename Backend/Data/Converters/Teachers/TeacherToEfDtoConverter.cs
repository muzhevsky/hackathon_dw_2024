using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Data.Converters.Teachers;

public class TeacherToEfDtoConverter: IConverter<Teacher, EfTeacherDto>
{
    public EfTeacherDto Convert(Teacher convertable)
    {
        return new EfTeacherDto
        {
            Id = convertable.Id,
            UserId = convertable.UserId,
            DepartmentId = convertable.DepartmentId
        };
    }
}