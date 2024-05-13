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
    StudentProfileUseCase _useCase;

    public StudentProfileController(StudentProfileUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost("/achievements")]
    [Authorize]
    public IActionResult AddAchievement([FromForm] AddAchievementRequest request)
    {
        Console.WriteLine(int.Parse(User.Claims.First(claim => claim.Type == "id").Value));
        _useCase.AddAchievement(request, int.Parse(User.Claims.First(claim => claim.Type == "id").Value));
        return Ok();
    }

    [HttpGet("/achievements")]
    [Authorize]
    public ActionResult<List<Achievement>> GetAchievements()
    {
        return Ok(
            _useCase.GetAchievements(
                int.Parse(User.Claims.First(claim => claim.Type == "id").Value)));
    }
}