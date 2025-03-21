using AgroFile.Application.Dtos.Authentication;
using AgroFile.Application.Interfaces.Validators;
using AgroFile.Application.Messages;
using AgroFile.Domain.Common;
using AgroFile.Domain.Interfaces;

namespace AgroFile.Application.Validators; 

public class AuthenticationValidator : IAuthenticationValidator
{
    private readonly IAuthenticationRepository _authenticationRepository;

    public AuthenticationValidator(IAuthenticationRepository authenticationRepository)
    {
        _authenticationRepository = authenticationRepository;
    }

    public async Task<Result> ValidateAuthenticationUser(SignInDTO informationForAuthentication)
    {
        return await ValidateUserEmailConfirmed(informationForAuthentication); 
    }

    private async Task<Result> ValidateUserEmailConfirmed(SignInDTO informationForAuthentication)
    {
        bool emailConfirmed = await _authenticationRepository.EmailConfirmed(informationForAuthentication.Email);

        if (!emailConfirmed) return Result.Failure(MessagesAuthenticationAgroFileApplication.EmailNotConfirmed);

        return Result.Success(string.Empty); 
    }
}
