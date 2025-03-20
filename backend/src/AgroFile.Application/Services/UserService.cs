using AgroFile.Application.Dtos.User;
using AgroFile.Application.Exceptions;
using AgroFile.Application.Exceptions.Messages;
using AgroFile.Application.Interfaces;
using AgroFile.Application.Interfaces.Validators;
using AgroFile.Domain.Common;
using AgroFile.Domain.Entities;
using AgroFile.Domain.Interfaces;
using Mapster;

namespace AgroFile.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    private readonly IUserValidator _userValidator;

    public UserService(IUserRepository userRepository, IPasswordService passwordService, IUserValidator userValidator)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
        _userValidator = userValidator;
    }

    public async Task<UserSummaryDTO> GetUser(string id)
    {
        User userEntity = await _userRepository.GetUser(id); 
        return userEntity.Adapt<UserSummaryDTO>();
    }

    public async Task<PaginedResult<UserSummaryDTO>> GetUsers(PaginationParams parameters)
    {
        PaginedResult<User> entitiesPaginedResult = await _userRepository.GetUsers(parameters);
        return entitiesPaginedResult.Adapt<PaginedResult<UserSummaryDTO>>();
    }

    public async Task<bool> CreateUser(UserDTO user)
    {
        await _userValidator.ValidateUser(user);

        User userEntity = MapToUserEntityOnCreate(user); 
        bool crateResult = await _userRepository.CreateUser(userEntity, _passwordService.GenerateRandomPassword());

        if (!crateResult) throw new AgroFileApplicationException(MessagesUserAgroFileApplicationException.CreateFailure);

        return true; 
    }

    private User MapToUserEntityOnCreate(UserDTO user)
    {
        User userEntity = user.Adapt<User>();

        userEntity.Id = Guid.NewGuid().ToString();
        userEntity.SecurityStamp = Guid.NewGuid().ToString();

        return userEntity; 
    }

    public async Task<bool> UpdateUser(UserDTO user)
    {
        await _userValidator.ValidateUser(user);

        User userEntity = await MapToUserEntityOnUpdate(user); 
        bool updateResult = await _userRepository.UpdateUser(userEntity);

        if (!updateResult) throw new AgroFileApplicationException(MessagesUserAgroFileApplicationException.UpdateFailure);

        return true;
    }

    private async Task<User> MapToUserEntityOnUpdate(UserDTO user)
    {
        User userEntity = await _userRepository.GetUser(user.Id);
        user.Adapt(userEntity); 

        return userEntity;
    }

    public async Task<bool> DeleteUser(string id)
    {
        User userEntity = await _userRepository.GetUser(id);
        bool deleteResult = await _userRepository.DeleteUser(userEntity);

        if (!deleteResult) throw new AgroFileApplicationException(MessagesUserAgroFileApplicationException.DeleteFailure);

        return true;
    }
}
