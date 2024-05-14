using Hackaton_DW_2024.Api.Auth;
using Hackaton_DW_2024.Api.Student;
using Hackaton_DW_2024.Infrastructure.Repositories.Database;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.UseCases;
using Hackaton_DW_2024.Internal.UseCases.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_DW_2024.Api;

[ApiController]
[Route("/")]
public class StudentController : ControllerBase
{
    StudentRequestUseCase _requestUseCase;
    StudentAchievementsUseCase _achievementsUseCase;
    EventsRepository _eventsRepository;

    public StudentController(StudentAchievementsUseCase achievementsUseCase, StudentRequestUseCase requestUseCase,
        EventsRepository eventsRepository)
    {
        _achievementsUseCase = achievementsUseCase;
        _requestUseCase = requestUseCase;
        _eventsRepository = eventsRepository;
    }

    [HttpPost("/achievement/attach")]
    public async Task<IActionResult> AttachAchievementFile([FromForm] AddAchievementFileRequest fileRequest)
    {
        var res = await _achievementsUseCase.AddAchievement(fileRequest,
            this.UserId() ?? throw new AuthException("unauthorized"));
        return Ok(res);
    }

    [HttpPost("/achievement/connected")]
    public ActionResult AddConnectedAchievement([FromBody] AddConnectedAchievementRequest request)
    {
        _achievementsUseCase.AddConnected(request);
        return Ok("done");
    }

    [HttpPost("/achievement/custom")]
    public ActionResult AddCustomAchievement([FromBody] AddCustomAchievementRequest request)
    {
        _achievementsUseCase.AddCustom(request);
        return Ok("done");
    }

    [HttpGet("/achievement")]
    public ActionResult<Achievement> GetAchievementById([FromQuery] int achievementId)
    {
        return Ok(_achievementsUseCase.GetAchievement(achievementId));
    }

    [HttpGet("/achievements")]
    public ActionResult<List<Achievement>> GetAchievements()
    {
        return Ok(_achievementsUseCase.GetAchievements(this.UserId() ?? throw new AuthException("unauthorized")));
    }

    [HttpPost("/request")]
    public ActionResult GenerateDoc([FromBody] AchievementSetRequest request)
    {
        _requestUseCase.SendRequest(request, this.UserId() ?? throw new AuthException("unauthorized"));
        return Ok("done");
    }

    [HttpGet("/student")]
    public ActionResult<StudentBasicDataResponse> GetStudent([FromQuery] int id)
    {
        return _requestUseCase.GetStudent(id);
    }

    [HttpPost("/event/subscribe")]
    public ActionResult SubscribeOnEvent([FromQuery] int eventId)
    {
        _eventsRepository.AddToUser(eventId, this.UserId() ?? throw new AuthException("unauthorized"));
        return Ok("done");
    }

    [HttpPost("/event/unsubscribe")]
    public ActionResult Unsubscribe([FromQuery] int eventId)
    {
        _eventsRepository.RemoveFromUser(eventId, this.UserId() ?? throw new AuthException("unauthorized"));
        return Ok("done");
    }
}