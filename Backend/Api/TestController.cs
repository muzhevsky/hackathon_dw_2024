using Hackaton_DW_2024.Internal.Data.DataSources.Achievements;
using Hackaton_DW_2024.Internal.Data.DataSources.FileSystem;
using Hackaton_DW_2024.Internal.Data.Dto.Achievements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_DW_2024.Api;

[ApiController]
[Authorize]
[Route("/")]
public class TestController: ControllerBase
{
    IFileSystem _fs;
    IAchievementsDataSource _asd;
    public TestController(IFileSystem fs, IAchievementsDataSource asd)
    {
        _fs = fs;
        _asd = asd;
    }
    
    [HttpGet("/hello")]
    public IActionResult Test([FromQuery] string fileName)
    {
        var file = _fs.Read(fileName);
        return File(file.Content, "application/octet-stream");
    }
    
        
    [HttpPost("/hello")]
    public IActionResult TestPost([FromQuery] string fileName, IFormFile file)
    {
        using var stream = file.OpenReadStream();
        using var bytes = new BinaryReader(stream);

        var content = bytes.ReadBytes((int)stream.Length);
        
        _fs.Write(new FileDto
        {
            Name = fileName,
            Content = content
        });
        
        return Ok();
    }
}