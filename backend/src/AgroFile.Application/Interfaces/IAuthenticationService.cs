using AgroFile.Application.Dtos.Authentication;

namespace AgroFile.Application.Interfaces;

public interface IAuthenticationService
{
    Task<UserSessionDTO> Login(LoginDTO informationForAuthentication); 
}
