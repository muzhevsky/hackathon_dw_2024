using Hackaton_DW_2024.Api.Requests;
using Hackaton_DW_2024.Internal.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_DW_2024.Api;

[ApiController]
[Route("/auth")]
public class AuthController: ControllerBase
{
    AuthUseCase _authUseCase;

    public AuthController(AuthUseCase authUseCase)
    {
        _authUseCase = authUseCase;
    }

    [HttpPost("/signup")]
    public IActionResult SignUp([FromBody] SignUpRequest request)
    {
        return Ok(_authUseCase.SignUp(request));
    }

    [HttpPost("/signin")]
    public IActionResult SignIn([FromBody] SignInRequest request)
    {
        return Ok(_authUseCase.SignIn(request));
    }
}