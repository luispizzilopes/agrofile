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
        bool result = await _userService.CreateUser(user);
        return result ? Ok("Usuário adicionado com sucesso!") : BadRequest("Não foi possível adicionar o usuário!");
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUser([FromBody] UserDTO user)
    {
        bool result = await _userService.UpdateUser(user);
        return result ? Ok("Usuário atualizado com sucesso!") : BadRequest("Não foi possível atualizar o usuário!");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] string id)
    {
        bool result = await _userService.DeleteUser(id);
        return result ? Ok("Usuário deletado com sucesso!") : BadRequest("Não foi possível deletar o usuário!");
    }
}
