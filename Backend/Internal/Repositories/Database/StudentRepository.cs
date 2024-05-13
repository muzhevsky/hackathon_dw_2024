using Hackaton_DW_2024.Data.DataSources.Students;
using Hackaton_DW_2024.Data.DataSources.Users;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Converters;
using Hackaton_DW_2024.Internal.Entities.Users;

namespace Hackaton_DW_2024.Internal.Repositories.Database;

public class StudentRepository
{
    IStudentsDataSource _studentsDataSource;
    IConverter<StudentDto, Student> _studentFromDtoConverter;
    IConverter<Student, StudentDto> _studentToDtoConverter;

    public StudentRepository(
        IStudentsDataSource studentsDataSource,
        IConverter<StudentDto, Student> studentFromDtoConverter, 
        IConverter<Student, StudentDto> studentToDtoConverter)
    {
        _studentsDataSource = studentsDataSource;
        _studentFromDtoConverter = studentFromDtoConverter;
        _studentToDtoConverter = studentToDtoConverter;
    }

    public void CreateStudent(Student student)
    {
        var id = _studentsDataSource.Insert(_studentToDtoConverter.Convert(student));
        student.Id = id;
    }

    public Student? GetStudent(int id)
    {
        var dto = _studentsDataSource.SelectById(id);
        if (dto == null) return null;

        var student = _studentFromDtoConverter.Convert(dto);
        return student;
    }

    public Student? GetStudentByUserId(int userId)
    {
        var dto = _studentsDataSource.SelectByUserId(userId);
        if (dto == null) return null;
        
        var student = _studentFromDtoConverter.Convert(dto);
        return student;
    }
}