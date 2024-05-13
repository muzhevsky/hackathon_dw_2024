using Hackaton_DW_2024.Api.Auth;
using Hackaton_DW_2024.Infrastructure.Repositories.Api;
using Hackaton_DW_2024.Infrastructure.Repositories.Database;

namespace Hackaton_DW_2024.Internal.UseCases;

public class StudentRequestUseCase
{
    StudentRepository _studentRepository;
    InstituteStructureRepository _instituteStructureRepository;
    AchievementsRepository _achievementsRepository;
    DocFileRepository _docFileRepository;

    public StudentRequestUseCase(
        StudentRepository studentRepository, 
        InstituteStructureRepository instituteStructureRepository, 
        DocFileRepository docFileRepository, 
        AchievementsRepository achievementsRepository)
    {
        _studentRepository = studentRepository;
        _instituteStructureRepository = instituteStructureRepository;
        _docFileRepository = docFileRepository;
        _achievementsRepository = achievementsRepository;
    }

    public void SendRequest(int userId)
    {
        var studentDetails = _studentRepository.GetStudentDetailsByUserId(userId);
        var groupDetails = _instituteStructureRepository.GetGroupDetails(studentDetails.Group.Id);
        _docFileRepository.GenerateDoc(studentDetails, groupDetails);
    }
    
    public StudentBasicDataResponse GetStudent(int userId)
    {
        var details = _studentRepository.GetStudentDetailsByUserId(userId);
        return new StudentBasicDataResponse
        {
            StudentId = details.Student.StudentId,
            UserId = details.Student.UserId,
            Id = details.Student.Id,
            Surname = details.User.Surname,
            Name = details.User.Name,
            Patronymic = details.User.Patronymic,
            GroupId = details.Student.GroupId,
            Telegram = details.Student.Telegram,
            PhoneNumber = details.Student.PhoneNumber
        };
    }
}