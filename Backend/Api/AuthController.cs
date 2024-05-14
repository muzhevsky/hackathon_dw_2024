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

    [HttpPost("/signup/student")]
    public ActionResult<SignUpResponse> SignUp([FromBody] StudentSignUpRequest request)
    {
        return Ok(_authUseCase.SignUpStudent(request));
    }
    
    [HttpPost("/signup/teacher")]
    public ActionResult<SignUpResponse> SignUp([FromBody] TeacherSignUpRequest request)
    {
        return Ok(_authUseCase.SignUpTeacher(request));
    }

    [HttpPost("/signin")]
    public ActionResult<SignInResponse> SignIn([FromBody] SignInRequest request)
    {
        return Ok(_authUseCase.SignIn(request));
    }
}