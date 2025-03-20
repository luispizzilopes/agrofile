using AgroFile.Domain.Common;
using AgroFile.Domain.Exceptions;
using AgroFile.Domain.Messages;

namespace AgroFile.Domain.Entities;

public class PaymentMethod : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    public ICollection<AccountTransaction>? AccountTransactions { get; set; }

    private PaymentMethod() { }

    public PaymentMethod(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new AgroFileDomainException(MessagesPaymentMethodAgroFileDomain.NameIsRequired);

        if(string.IsNullOrEmpty(description))
            throw new AgroFileDomainException(MessagesPaymentMethodAgroFileDomain.DescriptionIsRequired);

        Name = name;
        Description = description;
    }

    public static PaymentMethod Create(string name, string description)
    {
        return new PaymentMethod(name, description);
    }
}
