using AgroFile.Application.Dtos.Email;
using AgroFile.Application.Exceptions;
using AgroFile.Application.Interfaces;
using AgroFile.Application.Messages;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace AgroFile.Application.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration; 

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendMail(SendMailDTO sendMail)
    {
        SmtpClient smtpClient = GetConfigurationParamsEmail();
        MailMessage mailMessage = GetMailMessage(sendMail);

        try
        {
            await smtpClient.SendMailAsync(mailMessage); 
        }
        catch(Exception e)
        {
            throw new AgroFileApplicationException(MessagesEmailAgroFileApplication.SendMailFailure + " " + e.Message); 
        }
    }

    private MailMessage GetMailMessage(SendMailDTO sendMail)
    {
        IConfigurationSection configurationSection = GetConfigurationSectionEmailParams();
        MailMessage message = new();

        message.From = new MailAddress(configurationSection["Email"]!);
        message.To.Add(sendMail.SendTo);
        message.Subject = "eXtend File";
        message.Body = sendMail.Content;
        message.IsBodyHtml = sendMail.IsBodyHtml;

        return message; 
    }

    private SmtpClient GetConfigurationParamsEmail()
    {
        IConfigurationSection configurationSection = GetConfigurationSectionEmailParams();
        SmtpClient smtpClient = new(configurationSection["SmtpClient"], int.Parse(configurationSection["Port"]!));
        smtpClient.EnableSsl = bool.Parse(configurationSection["EnabledSsl"]!);
        smtpClient.Credentials = new NetworkCredential(configurationSection["Email"], configurationSection["Password"]); 

        return smtpClient;
    }

    private IConfigurationSection GetConfigurationSectionEmailParams()
    {
        return _configuration.GetSection("EmailParams");
    }
}
