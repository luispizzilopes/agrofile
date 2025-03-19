using AgroFile.Application.Dtos.Authentication;
using AgroFile.Application.Exceptions;
using AgroFile.Application.Exceptions.Messages;
using AgroFile.Application.Interfaces;
using AgroFile.Domain.Entities;
using AgroFile.Domain.Interfaces;

namespace AgroFile.Application.Services; 

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationRepository _authenticationRepository; 
    private readonly IUserRepository _userRepository;
    private readonly ITokenJwtService _tokenJwtService;

    public AuthenticationService(IAuthenticationRepository authenticationRepository, IUserRepository userRepository, ITokenJwtService tokenJwtService)
    {
        _authenticationRepository = authenticationRepository;
        _userRepository = userRepository;
        _tokenJwtService = tokenJwtService;
    }

    public async Task<UserSessionDTO> Login(LoginDTO informationForAuthentication)
    {
        bool informationProvidedIsValidForAuthentication = 
            await _authenticationRepository.PasswordSignIn(informationForAuthentication.Email, informationForAuthentication.Password);

        if (informationProvidedIsValidForAuthentication is false) 
            throw new AgroFileApplicationException(MessagesAuthenticationAgroFileApplicationException.AuthenticationFailure);

        return await GetUserSession(informationForAuthentication.Email); 
    }

    private async Task<UserSessionDTO> GetUserSession(string email)
    {
        User user = await _userRepository.GetUserByEmail(email);
        return new UserSessionDTO(user.Id, email, _tokenJwtService.CreateTokenUser(user)); 
    }
}
