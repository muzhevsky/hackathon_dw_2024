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

    public async Task<string> AddAchievement(AddAchievementRequest request, int userId)
    {
        var student = _studentRepository.GetStudentByUserId(userId);
        if (student == null)
        {
            _logger.Warn("user not found");
            return "";
        }

        var achievement = new Achievement
        {
            UserId = userId,
            TeamSize = request.TeamSize,
            Score = 0,
            FilePath = request.File.FileName
        };

        _achievementsRepository.AddAchievement(achievement, request.File.OpenReadStream());
        var res = await _recognitionRepository.Recognize(achievement.FilePath);
        await _gigaChatRepository.Authorize();
        return await _gigaChatRepository.SendMessage($"Распознай в представленном тексте данные в формате:" +
                                                     "Название конкурса: \n" +
                                                     "Имя участника: \n" +
                                                     "Дата проведения: \n" +
                                                     "Статус (региональный, международный и т.д): \n" +
                                                     "Занятое на конкурсе место:\n " +
                                                     $"Вот текст: {res}");
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