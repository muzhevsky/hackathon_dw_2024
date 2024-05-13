using Hackaton_DW_2024.Api.Student;
using Hackaton_DW_2024.Infrastructure.Repositories.Api;
using Hackaton_DW_2024.Infrastructure.Repositories.Database;
using Hackaton_DW_2024.Internal.UseCases.Exceptions;

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

    public void ConfirmAchievement(AddCustomAchievementRequest request, int userId)
    {
        // var stored = _achievementsRepository.GetById(request.Id);
        // if (stored.UserId != userId) throw new AuthException("user is not owner of achievement");
        // _achievementsRepository.ConfirmAchievement(request, userId);
    }
}