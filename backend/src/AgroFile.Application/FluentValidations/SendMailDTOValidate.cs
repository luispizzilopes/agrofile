using AgroFile.Application.Dtos.Email;
using AgroFile.Application.Messages;
using FluentValidation;

namespace AgroFile.Application.FluentValidations; 

public class SendMailDTOValidate : AbstractValidator<SendMailDTO>
{
    public SendMailDTOValidate()
    {
        RuleFor(x => x.SendTo)
          .NotEmpty().WithMessage(MessagesEmailAgroFileApplication.SendToIsRequired)
          .EmailAddress().WithMessage(MessagesEmailAgroFileApplication.SendToIsIncorrect);

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage(MessagesEmailAgroFileApplication.ContentIsRequired);
    }
}
