using Hackaton_DW_2024.Api.Requests;
using Hackaton_DW_2024.Data.DataSources.Events;
using Hackaton_DW_2024.Data.DataSources.Users;
using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_DW_2024.Api;

[ApiController]
[Route("/auth")]
public class AuthController : ControllerBase
{
    UserAuthUseCase _userAuthUseCase;
    IUsersDataSource _usersDataSource;
    IEventsDataSource _eventsDataSource;

    public AuthController(UserAuthUseCase userAuthUseCase, IUsersDataSource usersDataSource, IEventsDataSource eventsDataSource)
    {
        _userAuthUseCase = userAuthUseCase;
        _usersDataSource = usersDataSource;
        _eventsDataSource = eventsDataSource;
    }

    [HttpPost("/signup")]
    public IActionResult SignUp([FromBody] StudentSignUpRequest request)
    {
        return Ok(_userAuthUseCase.SignUp(request));
    }

    [HttpPost("/signin")]
    public IActionResult SignIn([FromBody] SignInRequest request)
    {
        return Ok(_userAuthUseCase.SignIn(request));
    }

    [HttpPost("/event")]
    public IActionResult AddEvent([FromQuery] int userId, [FromQuery] int eventId)
    {
        var test = _usersDataSource.SelectAchievements(userId);
        Console.WriteLine(test.Count);
        return Ok(test);
    }
}