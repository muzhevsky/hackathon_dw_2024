using Hackaton_DW_2024.Internal.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_DW_2024.Api;

[ApiController]
[Route("/")]
public class StudentRequestController: ControllerBase
{
    StudentRequestUseCase _useCase;

    public StudentRequestController(StudentRequestUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost("/request")]
    public ActionResult GenerateDoc()
    {
        _useCase.SendRequest(int.Parse(User.Claims.First(c => c.Type=="id").Value));
        return Ok();
    }
}