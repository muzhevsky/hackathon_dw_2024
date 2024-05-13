using Hackaton_DW_2024.Api.Auth;
using Hackaton_DW_2024.Internal.UseCases;
using Hackaton_DW_2024.Internal.UseCases.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_DW_2024.Api;

[ApiController]
[Route("/auth")]
public class AuthController : ControllerBase
{
    AuthUseCase _authUseCase;

    public AuthController(AuthUseCase authUseCase)
    {
        _authUseCase = authUseCase;
    }

    [HttpPost("/signup")]
    public ActionResult<SignUpResponse> SignUp([FromBody] SignUpRequest request)
    {
        try
        {
            return Ok(_authUseCase.SignUpStudent(request));
        }
        catch (AuthException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpPost("/signin")]
    public ActionResult<SignInResponse> SignIn([FromBody] SignInRequest request)
    {
        try
        {
            return Ok(_authUseCase.SignIn(request));
        }
        catch (AuthException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }
}