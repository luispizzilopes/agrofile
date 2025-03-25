using AgroFile.Application.Consts;
using AgroFile.Application.Dtos.Email;
using AgroFile.Application.Dtos.User;
using AgroFile.Application.Exceptions;
using AgroFile.Application.Interfaces;
using AgroFile.Application.Interfaces.Validators;
using AgroFile.Application.Messages;
using AgroFile.Domain.Common;
using AgroFile.Domain.Entities;
using AgroFile.Domain.Interfaces;
using Mapster;
using Microsoft.Extensions.Configuration;

namespace AgroFile.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    private readonly IEmailService _emailService;
    private readonly ITemplateService _templateService; 
    private readonly IUserValidator _userValidator;
    private readonly IConfiguration _configuration;

    public UserService(IUserRepository userRepository, IPasswordService passwordService, IEmailService emailService, ITemplateService templateService, IUserValidator userValidator, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
        _emailService = emailService;
        _templateService = templateService;
        _userValidator = userValidator;
        _configuration = configuration;
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

    public async Task<Result> CreateUser(UserDTO user)
    {
        Result validationResult = await _userValidator.ValidateCreateUser(user);
        if (!validationResult.IsSuccess) return validationResult; 

        User userEntity = MapToUserEntityOnCreate(user); 
        string randomPassword = _passwordService.GenerateRandomPassword();
        bool crateResult = await _userRepository.CreateUser(userEntity, randomPassword);

        if (!crateResult) Result.Failure(MessagesUserAgroFileApplication.CreateFailure);

        await SendMailWithPasswordToUser(user, randomPassword); 

        return Result.Success(MessagesUserAgroFileApplication.CreateSuccess); 
    }

    private User MapToUserEntityOnCreate(UserDTO user)
    {
        User userEntity = user.Adapt<User>();

        userEntity.Id = Guid.NewGuid().ToString();
        userEntity.SecurityStamp = Guid.NewGuid().ToString();

        return userEntity; 
    }

    private async Task SendMailWithPasswordToUser(UserDTO user, string randomPassword)
    {
        SendMailDTO sendMail = new SendMailDTO
        {
            SendTo = user.Email,
            Content = GetTemplatePasswordUser(user, randomPassword), 
            IsBodyHtml = true
        };

        await _emailService.SendMail(sendMail); 
    }

    private string GetTemplatePasswordUser(UserDTO user, string randomPassword)
    {
        string templateString = _templateService.GetTemplate(Templates.TemplatePasswordUser);

        return templateString.Replace("{emailusuario}", user.Email)
                             .Replace("{senha}", randomPassword)
                             .Replace("{link}", _configuration.GetSection("Frontend")["Url"]); 
    }

    public async Task<Result> UpdateUser(UserDTO user)
    {
        Result validationResult = await _userValidator.ValidateUpdateUser(user);
        if (!validationResult.IsSuccess) return validationResult;

        User userEntity = await MapToUserEntityOnUpdate(user); 
        bool updateResult = await _userRepository.UpdateUser(userEntity);

        if (!updateResult) Result.Failure(MessagesUserAgroFileApplication.UpdateFailure);

        return Result.Success(MessagesUserAgroFileApplication.UpdateSuccess);
    }

    private async Task<User> MapToUserEntityOnUpdate(UserDTO user)
    {
        User userEntity = await _userRepository.GetUser(user.Id);
        user.Adapt(userEntity); 

        return userEntity;
    }

    public async Task<Result> DeleteUser(string id)
    {
        bool deleteResult = await _userRepository.DeleteUser(id);

        if (!deleteResult) Result.Failure(MessagesUserAgroFileApplication.DeleteFailure); 

        return Result.Success(MessagesUserAgroFileApplication.DeleteSuccess);
    }
}
