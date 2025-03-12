using AgroFile.Domain.Common;
using AgroFile.Domain.Enum;
using AgroFile.Domain.Exceptions;
using AgroFile.Domain.Exceptions.Messages;

namespace AgroFile.Domain.Entities; 

public class Account : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string SubTitle { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public AccountType Type { get; set; }
    public Guid AccountCategoryId { get; set; }
    public AccountCategory? AccountCategory { get; set; }

    public Account() { }

    public Account(string title, string subTitle, bool isActive, AccountType type, Guid accountCategoryId)
    {
        if (string.IsNullOrEmpty(title))
            throw new AgroFileDomainException(MessagesAccountAgroFileDomainException.TitleIsRequired); 

        if(string.IsNullOrEmpty(title))
            throw new AgroFileDomainException(MessagesAccountAgroFileDomainException.SubTitleIsRequired);

        Title = title;
        SubTitle = subTitle;
        IsActive = isActive;
        Type = type;
        AccountCategoryId = accountCategoryId;
    }

    public static Account Create(string title, string subTitle, bool isActive, AccountType type, Guid accountCategoryId)
    {
        return new Account(title, subTitle, isActive, type, accountCategoryId)
    }
}
