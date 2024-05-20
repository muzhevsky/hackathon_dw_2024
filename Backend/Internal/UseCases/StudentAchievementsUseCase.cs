// using Hackaton_DW_2024.Api.Student;
// using Hackaton_DW_2024.Infrastructure.Repositories.Api;
// using Hackaton_DW_2024.Infrastructure.Repositories.Database;
// using Hackaton_DW_2024.Internal.UseCases.Exceptions;
// using Newtonsoft.Json;
// using ILogger = Hackaton_DW_2024.Infrastructure.Logging.ILogger;
//
// namespace Hackaton_DW_2024.Internal.UseCases;
//
// public class StudentAchievementsUseCase
// {
//     StudentRepository _studentRepository;
//     AchievementsRepository _achievementsRepository;
//     RecognizeTextApiRepository _recognitionRepository;
//     GigaChatRepository _gigaChatRepository;
//     ILogger _logger;
//
//     public StudentAchievementsUseCase(
//         AchievementsRepository achievementsRepository,
//         StudentRepository studentRepository,
//         ILogger logger,
//         RecognizeTextApiRepository recognitionRepository,
//         GigaChatRepository gigaChatRepository)
//     {
//         _achievementsRepository = achievementsRepository;
//         _studentRepository = studentRepository;
//         _logger = logger;
//         _recognitionRepository = recognitionRepository;
//         _gigaChatRepository = gigaChatRepository;
//     }
//
//     public async Task<AddAchievementFileResponse> AddAchievement(AddAchievementFileRequest fileRequest, int userId)
//     {
//         var student = _studentRepository.GetStudentByUserId(userId);
//         if (student == null) throw new EntityNotFoundException("user not found");
//
//         var achievement = new Achievement
//         {
//             UserId = userId,
//             Score = 0,
//             FilePath = fileRequest.File.FileName,
//             ResultId = 1
//         };
//
//         _achievementsRepository.AddAchievement(achievement, fileRequest.File.OpenReadStream());
//         var res = await _recognitionRepository.Recognize(achievement.FilePath);
//         await _gigaChatRepository.Authorize();
//         
//         Console.WriteLine(res);
//         
//         var response = await _gigaChatRepository.SendMessage(
//             "Распознай в тексте данные в формате:" +
//             "{" +
//             "\"title\": название конкурса," +
//             "\"date\": дата проведения конкурса," +
//             "\"status\": статус конкурса (пример: региональный, международный и т.д)," +
//             "result: результат участия (пример: 3 место, 2 место, победитель, фииналист, полуфиналист, призер, участник)" +
//             "}" +
//             $"Текст: {res}");
//         try
//         {
//             var converted = JsonConvert.DeserializeObject<AddAchievementFileResponse>(response);
//             converted.Id = achievement.Id;
//             return converted;
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine(response);
//             Console.WriteLine(ex);
//         }
//
//         return null;
//     }
//
//     public List<Achievement> GetAchievements(int userId)
//     {
//         var student = _studentRepository.GetStudentByUserId(userId);
//         if (student == null) throw new EntityNotFoundException("no user found");
//
//         return _achievementsRepository.AchievementsOfStudent(student);
//     }
//
//     public Achievement GetAchievement(int achievementId)
//     {
//         var achievement = _achievementsRepository.GetById(achievementId);
//         if (achievement == null) throw new EntityNotFoundException("no achievement found");
//         return achievement;
//     }
//
//     public void AddConnected(AddConnectedAchievementRequest request)
//     {
//         var achievement = _achievementsRepository.GetById(request.Id);
//         if (achievement == null) throw new EntityNotFoundException("no achievement found");
//         achievement.WithTeam = request.WithTeam;
//         achievement.ResultId = request.ResultId;
//         _achievementsRepository.AttachToEvent(achievement, request.EventId);
//         _achievementsRepository.UpdateAchievement(achievement);
//     }
//
//     public void AddCustom(AddCustomAchievementRequest request)
//     {
//         var achievement = _achievementsRepository.GetById(request.Id);
//         if (achievement == null) throw new EntityNotFoundException("no achievement found");
//         _achievementsRepository.AddCustom(achievement, request);
//     }
// }