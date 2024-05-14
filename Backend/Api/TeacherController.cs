using Hackaton_DW_2024.Api.Teacher;
using Hackaton_DW_2024.Infrastructure.Repositories.Database;
using Hackaton_DW_2024.Internal.Entities.Users;
using Hackaton_DW_2024.Internal.UseCases.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_DW_2024.Api;

[ApiController]
[Route("/")]
public class TeacherController : ControllerBase
{
    UserRepository _userRepository;
    QuestRepository _questRepository;

    public TeacherController(UserRepository userRepository, QuestRepository questRepository)
    {
        _userRepository = userRepository;
        _questRepository = questRepository;
    }

<<<<<<< HEAD
    [HttpPost("/request")]
=======
    [HttpPost("/quest")]
>>>>>>> a8d0791eb8c9c5ddb34b82f7a31d94666b5cab08
    public ActionResult CreateQuest([FromBody] CreateQuestRequest request)
    {
        var userId = 0;
        try
        {
            userId = this.UserId();
            if (_userRepository.GetRole(userId) != Role.Teacher) throw new AuthException("no permissions");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(401);
        }
        
        _questRepository.Create(request, userId);
        return Ok();
    }
}