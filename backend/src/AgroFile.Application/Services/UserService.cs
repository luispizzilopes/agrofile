using AgroFile.Application.Dtos.User;
using AgroFile.Application.Exceptions;
using AgroFile.Application.Exceptions.Messages;
using AgroFile.Application.Interfaces;
using AgroFile.Domain.Common;
using AgroFile.Domain.Entities;
using AgroFile.Domain.Interfaces;
using Mapster;

namespace AgroFile.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;

    public UserService(IUserRepository userRepository, IPasswordService passwordService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
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
        string randomPassword = _passwordService.GenerateRandomPassword();

        User userEntity = user.Adapt<User>(); 

        userEntity.Id = Guid.NewGuid().ToString();
        userEntity.SecurityStamp = Guid.NewGuid().ToString();

        bool result = await _userRepository.CreateUser(userEntity, randomPassword);

        if (result is false) throw new AgroFileApplicationException(MessagesUserAgroFileApplicationException.CreateFailure);

        return result; 
    }

    public async Task<bool> UpdateUser(UserDTO user)
    {
        bool result = await _userRepository.UpdateUser(user.Adapt<User>());

        if (result is false) throw new AgroFileApplicationException(MessagesUserAgroFileApplicationException.UpdateFailure);

        return result;
    }

    public async Task<bool> DeleteUser(string id)
    {
        User userEntity = await _userRepository.GetUser(id);
        bool result = await _userRepository.DeleteUser(userEntity);

        if (result is false) throw new AgroFileApplicationException(MessagesUserAgroFileApplicationException.DeleteFailure);

        return result;
    }
}
