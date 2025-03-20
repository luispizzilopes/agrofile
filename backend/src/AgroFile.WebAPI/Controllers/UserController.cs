using AgroFile.Application.Dtos.User;
using AgroFile.Application.Interfaces;
using AgroFile.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace AgroFile.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<PaginedResult<UserSummaryDTO>>> GetUsers([FromQuery] PaginationParams parameters)
    {
        return await _userService.GetUsers(parameters); 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserSummaryDTO>> GetUser([FromRoute] string id)
    {
        return await _userService.GetUser(id);
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] UserDTO user)
    {
        Result result = await _userService.CreateUser(user);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUser([FromBody] UserDTO user)
    {
        Result result = await _userService.UpdateUser(user);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] string id)
    {
        Result result = await _userService.DeleteUser(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
