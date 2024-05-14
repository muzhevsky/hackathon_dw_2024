using Hackaton_DW_2024.Api.Auth;
using Hackaton_DW_2024.Api.Student;
using Hackaton_DW_2024.Infrastructure.Repositories.Api;
using Hackaton_DW_2024.Infrastructure.Repositories.Database;
using Hackaton_DW_2024.Internal.Entities;

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

    public int SendRequest(AchievementSetRequest request, int userId)
    {
        var studentDetails = _studentRepository.GetStudentDetailsByUserId(userId);
        var groupDetails = _instituteStructureRepository.GetGroupDetails(studentDetails.Group.Id);

        var achievements = new List<AchievementForRequest>();
        
        foreach (var id in request.Achievements)
        {
            achievements.Add(_achievementsRepository.GetAchievementForRequestById(id));
        }
        
        return _docFileRepository.GenerateDoc(studentDetails, groupDetails, achievements
            .Select(a => a.ToArray())
            .ToList());
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