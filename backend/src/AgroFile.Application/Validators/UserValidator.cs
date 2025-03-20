using AgroFile.Application.Dtos.User;
using AgroFile.Application.Exceptions;
using AgroFile.Application.Exceptions.Messages;
using AgroFile.Application.Interfaces.Validators;
using AgroFile.Domain.Entities;
using AgroFile.Domain.Interfaces;

namespace AgroFile.Application.Validators;

public class UserValidator : IUserValidator
{
    private readonly IUserRepository _userRepository;

    public UserValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task ValidateUser(UserDTO user)
    {
        User userEntity = await _userRepository.GetUserByEmail(user.Email);

        ValidateUserEmailExists(userEntity); 
    }

    private void ValidateUserEmailExists(User userEntity)
    {
        if (userEntity is not null) 
            throw new AgroFileApplicationException(MessagesUserAgroFileApplicationException.UserEmailAlreadyExists); 
    }
}
