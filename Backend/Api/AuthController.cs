using Hackaton_DW_2024.Api.Auth;
using Hackaton_DW_2024.Data.DataSources.Events;
using Hackaton_DW_2024.Data.DataSources.Users;
using Hackaton_DW_2024.Internal.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_DW_2024.Api;

[ApiController]
[Route("/auth")]
public class AuthController : ControllerBase
{
    AuthUseCase _authUseCase;
    IUsersDataSource _usersDataSource;
    IEventsDataSource _eventsDataSource;

    public AuthController(AuthUseCase authUseCase, IUsersDataSource usersDataSource, IEventsDataSource eventsDataSource)
    {
        _authUseCase = authUseCase;
        _usersDataSource = usersDataSource;
        _eventsDataSource = eventsDataSource;
    }

    [HttpPost("/signup")]
    public ActionResult<StudentSignUpResponse> SignUp([FromBody] StudentSignUpRequest request)
    {
        return Ok(_authUseCase.SignUpStudent(request));
    }

    [HttpPost("/signin")]
    public ActionResult<SignInResponse> SignIn([FromBody] SignInRequest request)
    {
        return Ok(_authUseCase.SignIn(request));
    }

    [HttpPost("/event")]
    public IActionResult AddEvent([FromQuery] int userId, [FromQuery] int eventId)
    {
        var test = _usersDataSource.SelectById(userId);
        return Ok(test);
    }
}