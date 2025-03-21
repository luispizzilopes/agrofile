using AgroFile.Application.Dtos.Authentication;
using AgroFile.Application.Interfaces;
using AgroFile.Domain.Common;
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
}
