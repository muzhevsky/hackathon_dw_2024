using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Infrastructure.Repositories.Database;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_DW_2024.Api;

[ApiController]
[Route("/")]
public class InstituteStructureController:ControllerBase
{
    InstituteStructureRepository _instituteStructureRepository;

    public InstituteStructureController(InstituteStructureRepository instituteStructureRepository)
    {
        _instituteStructureRepository = instituteStructureRepository;
    }

    [HttpGet("/groups")]
    public ActionResult<GroupDto> GetGroups()
    {
        return Ok(_instituteStructureRepository.GetGroups());
    } 
}