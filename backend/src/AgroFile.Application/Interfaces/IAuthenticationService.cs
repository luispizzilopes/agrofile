using AgroFile.Application.Dtos.Authentication;
using AgroFile.Domain.Common;
using AgroFile.Shared.Common;

namespace AgroFile.Application.Interfaces;

public interface IAuthenticationService
{
    Task<ResultWithValue<UserSessionDTO>> SignIn(SignInDTO informationForAuthentication);
    Task<Result> PasswordReset(PasswordResetDTO inforationForResetPassword);
    Task<Result> ConfirmPasswordReset(ConfirmPasswordResetDTO confirmPasswordReset); 
}
