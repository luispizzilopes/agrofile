using AgroFile.Domain.Common;
using AgroFile.Domain.Exceptions;
using AgroFile.Domain.Exceptions.Messages;

namespace AgroFile.Domain.Entities; 

public class AccountCategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty; 

    public ICollection<Account>? Accounts { get; set; }

    public AccountCategory() { }

    public AccountCategory(string name, string description)
    {
        if (string.IsNullOrEmpty(name))
            throw new AgroFileDomainException(MessagesAccountCategoryAgroFileDomainException.NameIsRequired);

        if (string.IsNullOrEmpty(description))
            throw new AgroFileDomainException(MessagesAccountCategoryAgroFileDomainException.DescriptionIsRequired);

        Name = name;
        Description = description;
    }

    public static AccountCategory Create(string name, string description)
    {
        return new AccountCategory(name, description);
    }
}
