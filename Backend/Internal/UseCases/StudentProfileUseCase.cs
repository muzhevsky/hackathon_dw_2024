using Hackaton_DW_2024.Api.Student;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.Repositories;
using Hackaton_DW_2024.Internal.Repositories.Api;
using Hackaton_DW_2024.Internal.Repositories.Database;
using ILogger = Hackaton_DW_2024.Infrastructure.Logging.ILogger;

namespace Hackaton_DW_2024.Internal.UseCases;

public class StudentProfileUseCase
{
    StudentRepository _studentRepository;
    AchievementsRepository _achievementsRepository;
    RecognizeTextApiRepository _recognitionRepository;
    GigaChatRepository _gigaChatRepository;
    ILogger _logger;

    public StudentProfileUseCase(
        AchievementsRepository achievementsRepository, 
        StudentRepository studentRepository, 
        ILogger logger, RecognizeTextApiRepository recognitionRepository, GigaChatRepository gigaChatRepository)
    {
        _achievementsRepository = achievementsRepository;
        _studentRepository = studentRepository;
        _logger = logger;
        _recognitionRepository = recognitionRepository;
        _gigaChatRepository = gigaChatRepository;
    }

    public async void AddAchievement(AddAchievementRequest request, int userId)
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
            Score = 0,
            FilePath = request.File.FileName
        };
        
        _achievementsRepository.AddAchievement(achievement, request.File.OpenReadStream());
         _recognitionRepository.Test(achievement.FilePath);
        await _gigaChatRepository.Authorize();
        await _gigaChatRepository.SendMessage("Привет, Гигачат!");
    }

    public List<Achievement> GetAchievements(int userId)
    {
        var student = _studentRepository.GetStudentByUserId(userId);
        if (student == null)
        {
            _logger.Warn("user not found");
            return new List<Achievement>();
        }
        return _achievementsRepository.AchievementsOfStudent(student);
    }
}