using AgroFile.Application.Dtos.Authentication;
using AgroFile.Application.Interfaces;
using AgroFile.Shared.Common;
using Microsoft.AspNetCore.Mvc;

namespace AgroFile.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("sign-in")]
    public async Task<ActionResult> SignIn([FromBody] SignInDTO informationForAuthentication)
    {
        ResultWithValue<UserSessionDTO> result = await _authenticationService.SignIn(informationForAuthentication);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost("reset-password")]
    public async Task<ActionResult> ResetPassword([FromBody] PasswordResetDTO informationForResetPassword)
    {
        Result result = await _authenticationService.PasswordReset(informationForResetPassword);
        return result.IsSuccess ? Ok(result) : BadRequest(result); 
    }

    [HttpGet("confirm-reset-password")]
    public async Task<ActionResult> ConfirmResetPassword([FromQuery] string token, [FromQuery] string email)
    {
        Result result = await _authenticationService.ConfirmPasswordReset(new ConfirmPasswordResetDTO(token, email));
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
