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

    [HttpPost("/achievement/attach")]
    [Authorize]
    public async Task<IActionResult> AttachAchievementFile([FromForm] AddAchievementFileRequest fileRequest)
    {
        var res = await _achievementsUseCase.AddAchievement(fileRequest, this.UserId());
        return Ok(res);
    }

    [HttpPost("/achievement/connected")]
    public ActionResult AddConnectedAchievement([FromBody] AddConnectedAchievementRequest request)
    {
        _achievementsUseCase.AddConnected(request);
        return Ok();
    }
    
    // [HttpPost("/achievement/custom")]
    // public ActionResult AddCustomAchievement([FromBody] AddCustomAchievementRequest request)
    // {
    //     _achievementsUseCase.AddCustom(request);
    //     return Ok();
    // }

    [HttpGet("/achievements")]
    [Authorize]
    public ActionResult<List<Achievement>> GetAchievements()
    {
        return Ok(_achievementsUseCase.GetAchievements(this.UserId()));
    }


}

public static class ControllerExtension
{
    public static int UserId(this ControllerBase controller)
    {
        return int.Parse(controller.User.Claims.First(claim => claim.Type == "id").Value);
    }
}