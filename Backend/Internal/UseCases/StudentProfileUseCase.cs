using Hackaton_DW_2024.Api.Requests;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.Repositories;
using Entities_File = Hackaton_DW_2024.Internal.Entities.File;
using Logging_ILogger = Hackaton_DW_2024.Infrastructure.Logging.ILogger;

namespace Hackaton_DW_2024.Internal.UseCases;

public class StudentProfileUseCase
{
    StudentRepository _studentRepository;
    AchievementsRepository _achievementsRepository;
    ITokenProvider _tokenProvider;
    Logging_ILogger _logger;

    public StudentProfileUseCase(
        AchievementsRepository achievementsRepository, 
        StudentRepository studentRepository, 
        Logging_ILogger logger, 
        ITokenProvider tokenProvider)
    {
        _achievementsRepository = achievementsRepository;
        _studentRepository = studentRepository;
        _logger = logger;
        _tokenProvider = tokenProvider;
    }

    public void AddAchievement(AddAchievementRequest request, int userId)
    {
        var student = _studentRepository.GetStudentByUserId(userId);
        if (student == null)
        {
            _logger.Warn("user not found");
            return;
        }
        
        var achievement = new Achievement
        {
            UserId = userId,
            TeamSize = request.TeamSize,
            Score = 0
        };
        
        _achievementsRepository.AddAchievement(achievement);
    }

    public List<Achievement> GetAchievements(int userId)
    {
        Console.WriteLine(userId);
        var student = _studentRepository.GetStudentByUserId(userId);
        if (student == null)
        {
            _logger.Warn("user not found");
            return new List<Achievement>();
        }
        return _achievementsRepository.AchievementsOfStudent(student);
    }
}