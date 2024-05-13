using Hackaton_DW_2024.Api.Auth;
using Hackaton_DW_2024.Api.Student;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_DW_2024.Api;

[ApiController]
[Route("/student")]
public class StudentProfileController : ControllerBase
{
    StudentAchievementsUseCase _achievementsUseCase;

    public StudentProfileController(StudentAchievementsUseCase achievementsUseCase)
    {
        _achievementsUseCase = achievementsUseCase;
    }

    [HttpPost("/achievements")]
    [Authorize]
    public async Task<IActionResult> AddAchievementFile([FromForm] AddAchievementFileRequest fileRequest)
    {
        var res = await _achievementsUseCase.AddAchievement(fileRequest, this.UserId());
        return Ok(res);
    }

    [HttpGet("/achievements")]
    [Authorize]
    public ActionResult<List<Achievement>> GetAchievements()
    {
        return Ok(_achievementsUseCase.GetAchievements(this.UserId()));
    }

    [HttpGet("/student")]
    [Authorize]
    public ActionResult<StudentBasicDataResponse> GetStudent()
    {
        return _achievementsUseCase.GetStudent(this.UserId());
    }
}

public static class ControllerExtension
{
    public static int UserId(this ControllerBase controller)
    {
        return int.Parse(controller.User.Claims.First(claim => claim.Type == "id").Value);
    }
}