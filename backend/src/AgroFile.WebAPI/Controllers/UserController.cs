using AgroFile.Application.Dtos.User;
using AgroFile.Application.Interfaces;
using AgroFile.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace AgroFile.WebAPI.Controllers; 

/// <summary>
/// Controller responsible for user operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    /// <summary>
    /// Constructor of the UserController class.
    /// </summary>
    /// <param name="userService">User service.</param>
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Retrieves a paginated list of users.
    /// </summary>
    /// <param name="parameters">Pagination parameters.</param>
    /// <returns>Paginated list of users.</returns>
    [HttpGet]
    public async Task<ActionResult<PaginedResult<UserSummaryDTO>>> GetUsers([FromQuery] PaginationParams parameters)
    {
        return await _userService.GetUsers(parameters);
    }

    /// <summary>
    /// Retrieves a user by their ID.
    /// </summary>
    /// <param name="id">User ID.</param>
    /// <returns>Found user.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<UserSummaryDTO>> GetUser([FromRoute] string id)
    {
        return await _userService.GetUser(id);
    }

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="user">User data to create.</param>
    /// <returns>Operation result.</returns>
    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] UserDTO user)
    {
        Result result = await _userService.CreateUser(user);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    /// <summary>
    /// Updates an existing user.
    /// </summary>
    /// <param name="user">User data to update.</param>
    /// <returns>Operation result.</returns>
    [HttpPut]
    public async Task<ActionResult> UpdateUser([FromBody] UserDTO user)
    {
        Result result = await _userService.UpdateUser(user);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    /// <summary>
    /// Deletes a user by their ID.
    /// </summary>
    /// <param name="id">ID of the user to delete.</param>
    /// <returns>Operation result.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] string id)
    {
        Result result = await _userService.DeleteUser(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
