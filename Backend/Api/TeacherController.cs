using Hackaton_DW_2024.Api.Teacher;
using Hackaton_DW_2024.Data.Dto;
using Hackaton_DW_2024.Infrastructure.Repositories.Database;
using Hackaton_DW_2024.Internal.UseCases.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_DW_2024.Api;

[ApiController]
[Route("/")]
public class TeacherController : ControllerBase
{
    QuestRepository _questRepository;

    public TeacherController(QuestRepository questRepository)
    {
        _questRepository = questRepository;
    }

<<<<<<< HEAD
    [HttpPost("/request")]
=======
    [HttpPost("/quest")]
>>>>>>> a8d0791eb8c9c5ddb34b82f7a31d94666b5cab08
    public ActionResult CreateQuest([FromBody] CreateQuestRequest request)
    {
        var userId = this.UserId() ?? throw new AuthException("unauthorized");

        _questRepository.Create(request, userId);
        return Ok();
    }
    
    [HttpGet("/quest")]
    public ActionResult<QuestDto> GetQuest([FromQuery] int id)
    {
        return Ok( _questRepository.GetById(id));
    }
    
    [HttpGet("/group/quests")]
    public ActionResult<List<QuestDto>> GetQuestByGroup([FromQuery] int groupId)
    {
        return Ok( _questRepository.GetByGroupId(groupId));
    }
    
    [HttpGet("/event/quests")]
    public ActionResult<List<QuestDto>> GetQuestByEvent([FromQuery] int eventId)
    {
        return Ok( _questRepository.GetByEventId(eventId));
    }
    [HttpGet("/teacher/quests")]
    public ActionResult<List<QuestDto>> GetQuestByTeacher([FromQuery] int teacherId)
    {
        return Ok( _questRepository.GetByTeacherId(teacherId));
    }
}