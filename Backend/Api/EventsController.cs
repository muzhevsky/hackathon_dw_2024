using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Infrastructure.Repositories.Database;
using Hackaton_DW_2024.Internal.UseCases.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_DW_2024.Api;

[ApiController]
[Route("/")]
public class EventsController: ControllerBase
{
    EventsRepository _eventsRepository;

    public EventsController(EventsRepository eventsRepository)
    {
        _eventsRepository = eventsRepository;
    }

    [HttpGet("/event_statuses")]
    public ActionResult<List<EventStatusDto>> GetStatuses()
    {
        return Ok(_eventsRepository.GetAllStatuses());
    }

    [HttpGet("/event_status")]
    public ActionResult<EventStatusDto> GetStatus([FromQuery] int id)
    {
        return Ok(_eventsRepository.GetStatusById(id));
    }
    
    [HttpGet("/event_results")]
    public ActionResult<List<EventResultDto>> GetResults()
    {
        return Ok(_eventsRepository.GetAllResults());
    }

    [Authorize()]
    [HttpGet("/event_result")]
    public ActionResult<EventStatusDto> GetResult([FromQuery] int id)
    {
        return Ok(_eventsRepository.GetResultById(id));
    }

    [HttpGet("/events")]
    public ActionResult<List<EventDto>> GetEvents()
    {
        return Ok(_eventsRepository.GetAll());
    }
    
    [Authorize]
    [HttpGet("/myEvents")]
    public ActionResult<List<EventDto>> GetSubscribedEvents()
    {
        return Ok(_eventsRepository.GetByUserId(this.UserId() ?? throw new AuthException("unauthorized")));
    }
}