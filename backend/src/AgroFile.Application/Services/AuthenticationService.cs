using AgroFile.Application.Consts;
using AgroFile.Application.Dtos.Authentication;
using AgroFile.Application.Dtos.Email;
using AgroFile.Application.Dtos.User;
using AgroFile.Application.Extensions;
using AgroFile.Application.Interfaces;
using AgroFile.Application.Interfaces.Validators;
using AgroFile.Application.Messages;
using AgroFile.Domain.Common;
using AgroFile.Domain.Entities;
using AgroFile.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Web;

namespace AgroFile.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationRepository _authenticationRepository;
    private readonly IAuthenticationValidator _authenticationValidator;
    private readonly IConfiguration _configuration; 
    private readonly IHttpContextAccessor _httpContextAcessor; 
    private readonly IUserRepository _userRepository;
    private readonly ITokenJwtService _tokenJwtService;
    private readonly ITemplateService _templateService;
    private readonly IEmailService _emailService;
    private readonly IPasswordService _passwordService; 
    private readonly UserManager<User> _userManager;

    public AuthenticationService(IAuthenticationRepository authenticationRepository, IAuthenticationValidator authenticationValidator, IConfiguration configuration, IHttpContextAccessor httpContextAcessor, IUserRepository userRepository, ITokenJwtService tokenJwtService, ITemplateService templateService, IEmailService emailService, IPasswordService passwordService, UserManager<User> userManager)
    {
        _authenticationRepository = authenticationRepository;
        _authenticationValidator = authenticationValidator;
        _configuration = configuration;
        _httpContextAcessor = httpContextAcessor;
        _userRepository = userRepository;
        _tokenJwtService = tokenJwtService;
        _templateService = templateService;
        _emailService = emailService;
        _passwordService = passwordService;
        _userManager = userManager;
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
        UserSessionDTO session = new UserSessionDTO(user.Id, email, _tokenJwtService.CreateTokenUser(user));
        return ResultWithValue<UserSessionDTO>.Success(session, MessagesAuthenticationAgroFileApplication.AuthenticationSuccess);
    }

    private async Task RegisterSignInFailure(string email)
    {
        User user = await _userRepository.GetUserByEmail(email);
        user.AccessFailedCount++;  

        await _userRepository.UpdateUser(user);
    }

    public async Task<Result> PasswordReset(PasswordResetDTO inforationForResetPassword)
    {
        try
        {
            User user = await _userRepository.GetUserByEmail(inforationForResetPassword.Email);
            await GeneratePassowordResetToken(user);

            return Result.Success(MessagesAuthenticationAgroFileApplication.SendMailPasswordResetSuccess); 
        }
        catch
        {
            return Result.Failure(MessagesAuthenticationAgroFileApplication.SendMailPasswordResetFailure); 
        }
    }

    private async Task GeneratePassowordResetToken(User user)
    {
        string token = await _userManager.GeneratePasswordResetTokenAsync(user);

        await SendMailWithPasswordTokenToUser(user, token); 
    }

    private async Task SendMailWithPasswordTokenToUser(User user, string token)
    {
        SendMailDTO sendMail = new SendMailDTO
        {
            SendTo = user.Email!,
            Content = GetTemplatePasswordTokenUser(user, token),
            IsBodyHtml = true
        };

        await _emailService.SendMail(sendMail);
    }

    private string GetTemplatePasswordTokenUser(User user, string token)
    {
        string templateString = _templateService.GetTemplate(Templates.TemplateTokenPasswordUser);
        string baseUrl = _httpContextAcessor.HttpContext.GetBaseUrl();
        string tokenEncoded = Uri.EscapeDataString(token);
        string emailEncoded = Uri.EscapeDataString(user.Email!);
        string resetPasswordUrl = $"{baseUrl}/api/Authentication/confirm-reset-password?token={tokenEncoded}&email={emailEncoded}";

        return templateString.Replace("{emailusuario}", user.Email)
                             .Replace("{link}", resetPasswordUrl);

    }

    public async Task<Result> ConfirmPasswordReset(ConfirmPasswordResetDTO confirmPasswordReset)
    {
        confirmPasswordReset.Token = Uri.UnescapeDataString(confirmPasswordReset.Token);
        confirmPasswordReset.Email = Uri.UnescapeDataString(confirmPasswordReset.Email);

        User? user = await _userManager.FindByEmailAsync(confirmPasswordReset.Email);
        string newPassword = _passwordService.GenerateRandomPassword();

        var result = await _userManager.ResetPasswordAsync(user!, confirmPasswordReset.Token, newPassword);

        if (!result.Succeeded) return Result.Failure(MessagesAuthenticationAgroFileApplication.ConfirmPasswordResetFailure);

        await SendMailWithPasswordToUser(user!, newPassword);

        return Result.Success(MessagesAuthenticationAgroFileApplication.ConfirmPasswordResetSuccess); 
    }

    private async Task SendMailWithPasswordToUser(User user, string randomPassword)
    {
        SendMailDTO sendMail = new SendMailDTO
        {
            SendTo = user.Email,
            Content = GetTemplatePasswordUser(user, randomPassword),
            IsBodyHtml = true
        };

        await _emailService.SendMail(sendMail);
    }

    private string GetTemplatePasswordUser(User user, string randomPassword)
    {
        string templateString = _templateService.GetTemplate(Templates.TemplatePasswordUser);

        return templateString.Replace("{emailusuario}", user.Email)
                             .Replace("{senha}", randomPassword)
                             .Replace("{link}", _configuration.GetSection("Frontend")["Url"]);
    }
}
