using Hackaton_DW_2024.Data.DataSources;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_DW_2024.Controllers;

[ApiController]
[Route("/")]
public class HelloWorldController: ControllerBase
{
    UsersDataSource _ds;

    public HelloWorldController(UsersDataSource ds)
    {
        _ds = ds;
    }
    
    [HttpGet("/hello")]
    public IActionResult Test()
    {
        return Ok(_ds.Users.First());
    }
}