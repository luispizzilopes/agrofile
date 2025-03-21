using AgroFile.Application.Dtos.Authentication;
using AgroFile.Domain.Common;

namespace AgroFile.Application.Interfaces;

public interface IAuthenticationService
{
    Task<ResultWithValue<UserSessionDTO>> SignIn(SignInDTO informationForAuthentication); 
}
