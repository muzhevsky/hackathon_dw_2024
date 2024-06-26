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
    public ActionResult<List<GroupDto>> GetGroups()
    {
        return Ok(_instituteStructureRepository.GetAllGroups());
    }

    [HttpGet("/group")]
    public ActionResult<GroupDto> GetGroup([FromQuery] int id)
    {
        return Ok(_instituteStructureRepository.GetGroupById(id));
    }
    
    [HttpGet("/departments")]
    public ActionResult<List<DepartmentDto>> GetDepartments()
    {
        return Ok(_instituteStructureRepository.GetAllDepartments());
    }
    
    [HttpGet("/department")]
    public ActionResult<DepartmentDto> GetDepartment([FromQuery] int id)
    {
        return Ok(_instituteStructureRepository.GetDepartmentById(id));
    }
    
    [HttpGet("/institutes")]
    public ActionResult<List<InstituteDto>> GetInstitutes()
    {
        return Ok(_instituteStructureRepository.GetAllInstitutes());
    } 
    
    [HttpGet("/institute")]
    public ActionResult<InstituteDto> GetInstitute([FromQuery] int id)
    {
        return Ok(_instituteStructureRepository.GetInstituteById(id));
    }
        
    [HttpGet("/specialities")]
    public ActionResult<List<SpecialityDto>> GetSpecialities()
    {
        return Ok(_instituteStructureRepository.GetAllSpecialities());
    } 
    
    [HttpGet("/specialitiy")]
    public ActionResult<SpecialityDto> GetSpeciality([FromQuery] int id)
    {
        return Ok(_instituteStructureRepository.GetSpecialityById(id));
    }
}