using Hackaton_DW_2024.Data.Dto.Users;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Students;

public interface IStudentsDataSource
{
    EfStudentDto? SelectById(int id);
    EfStudentDto? SelectByUserId(int userId);
    EfStudentDto? SelectByStudentId(string studentId);
    int Insert(EfStudentDto dto);
    void UpdateByUserId(int userId, Action<EfStudentDto> updateFunc);
}