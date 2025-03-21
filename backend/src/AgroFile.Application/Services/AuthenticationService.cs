using AgroFile.Application.Dtos.Authentication;
using AgroFile.Application.Interfaces;
using AgroFile.Application.Interfaces.Validators;
using AgroFile.Application.Messages;
using AgroFile.Domain.Common;
using AgroFile.Domain.Entities;
using AgroFile.Domain.Interfaces;

namespace AgroFile.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationRepository _authenticationRepository;
    private readonly IAuthenticationValidator _authenticationValidator; 
    private readonly IUserRepository _userRepository;
    private readonly ITokenJwtService _tokenJwtService;

    public AuthenticationService(IAuthenticationRepository authenticationRepository, IAuthenticationValidator authenticationValidator, IUserRepository userRepository, ITokenJwtService tokenJwtService)
    {
        _authenticationRepository = authenticationRepository;
        _authenticationValidator = authenticationValidator;
        _userRepository = userRepository;
        _tokenJwtService = tokenJwtService;
    }

    public async Task<ResultWithValue<UserSessionDTO>> SignIn(SignInDTO informationForAuthentication)
    {
        Result validationResult = await _authenticationValidator.ValidateAuthenticationUser(informationForAuthentication);
        if (!validationResult.IsSuccess) return ResultWithValue<UserSessionDTO>.Failure(validationResult.ErrorMessage ?? string.Empty);

        bool informationProvidedIsValidForAuthentication =  await _authenticationRepository.PasswordSignIn(
            informationForAuthentication.Email, 
            informationForAuthentication.Password
        );

        if (!informationProvidedIsValidForAuthentication)
        {
            await RegisterSignInFailure(informationForAuthentication.Email);
            return ResultWithValue<UserSessionDTO>.Failure(MessagesAuthenticationAgroFileApplication.AuthenticationFailure);
        }

        return await CreateUserSession(informationForAuthentication.Email);
    }

    private async Task<ResultWithValue<UserSessionDTO>> CreateUserSession(string email)
    {
        User user = await _userRepository.GetUserByEmail(email);
        var session = new UserSessionDTO(user.Id, email, _tokenJwtService.CreateTokenUser(user));
        return ResultWithValue<UserSessionDTO>.Success(session, MessagesAuthenticationAgroFileApplication.AuthenticationSuccess);
    }

    private async Task RegisterSignInFailure(string email)
    {
        User user = await _userRepository.GetUserByEmail(email);
        user.AccessFailedCount++;  

        await _userRepository.UpdateUser(user);
    }
}
