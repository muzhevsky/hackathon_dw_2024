using Hackaton_DW_2024.Api.Auth;
using Hackaton_DW_2024.Internal.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_DW_2024.Api;

[ApiController]
[Route("/auth")]
public class AuthController : ControllerBase
{
    SignUpStudentUseCase _signUpStudentUseCase;
    SignUpTeacherUseCase _signUpTeacherUseCase;
    SignInUseCase _signInUseCase;

    public AuthController(
        SignUpStudentUseCase signUpStudentUseCase,
        SignUpTeacherUseCase signUpTeacherUseCase,
        SignInUseCase signInUseCase
    )
    {
        _signUpStudentUseCase = signUpStudentUseCase;
        _signInUseCase = signInUseCase;
        _signUpTeacherUseCase = signUpTeacherUseCase;
    }

    [HttpPost("/signup/student")]
    public ActionResult<SignUpResponse> SignUp([FromBody] StudentSignUpRequest request)
    {
        return Ok(_signUpStudentUseCase.SignUpStudent(request));
    }

    [HttpPost("/signup/teacher")]
    public ActionResult<SignUpResponse> SignUp([FromBody] TeacherSignUpRequest request)
    {
        return Ok(_signUpTeacherUseCase.SignUpTeacher(request));
    }

    [HttpPost("/signin")]
    public ActionResult<SignInResponse> SignIn([FromBody] SignInRequest request)
    {
        return Ok(_signInUseCase.SignIn(request));
    }
}