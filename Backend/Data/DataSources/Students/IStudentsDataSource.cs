using Hackaton_DW_2024.Data.Dto.Users;

namespace Hackaton_DW_2024.Data.DataSources.Students;

public interface IStudentsDataSource
{
    StudentDto? SelectById(int id);
    StudentDto? SelectByUserId(int userId);
    StudentDto? SelectByStudentId(string studentId);
    int Insert(StudentDto dto);
    void UpdateByUserId(int userId, Action<StudentDto> updateFunc);
}