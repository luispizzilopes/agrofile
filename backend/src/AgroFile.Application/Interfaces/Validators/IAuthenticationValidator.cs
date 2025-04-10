using AgroFile.Application.Dtos.Authentication;
using AgroFile.Domain.Common;
using AgroFile.Shared.Common;

namespace AgroFile.Application.Interfaces.Validators; 

public interface IAuthenticationValidator
{
    Task<Result> ValidateAuthenticationUser(SignInDTO informationForAuthentication); 
}
