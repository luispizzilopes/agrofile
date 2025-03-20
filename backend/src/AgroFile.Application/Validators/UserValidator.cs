using AgroFile.Application.Dtos.User;
using AgroFile.Application.Interfaces.Validators;
using AgroFile.Application.Messages;
using AgroFile.Domain.Common;
using AgroFile.Domain.Interfaces;

namespace AgroFile.Application.Validators;

public class UserValidator : IUserValidator
{
    private readonly IUserRepository _userRepository;

    public UserValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> ValidateCreateUser(UserDTO user)
    {
        return await ValidateUserEmailExists(user.Email); 
    }

    public async Task<Result> ValidateUpdateUser(UserDTO user)
    {
        if(!string.IsNullOrEmpty(user.NewEmail)) return await ValidateUserEmailExists(user.NewEmail);

        return Result.Success(string.Empty); 
    }

    private async Task<Result> ValidateUserEmailExists(string email)
    {
        bool exists = await _userRepository.UserEmailExists(email);

        if (exists) 
            return Result.Failure(MessagesUserAgroFileApplication.UserEmailAlreadyExists);

        return Result.Success(string.Empty); 
    }
}
