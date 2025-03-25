using AgroFile.Application.Dtos.Email;
using System.Net.Mail;

namespace AgroFile.Application.Interfaces; 

public interface IEmailService
{
    Task SendMail(SendMailDTO sendMail);
}
