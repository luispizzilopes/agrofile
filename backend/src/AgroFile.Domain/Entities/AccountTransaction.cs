using AgroFile.Domain.Common;
using AgroFile.Domain.Enums;
using AgroFile.Domain.Exceptions;
using System;
using AgroFile.Domain.Messages;

namespace AgroFile.Domain.Entities;
public class AccountTransaction : BaseEntity
{
    public decimal? TotalPrice { get; private set; }
    public TypeTransaction Type { get; private set; }
    public StatusAccountTransaction Status { get; private set; }
    public DateTime TransactionDate { get; private set; } = DateTime.UtcNow;
    public string? Description { get; private set; }

    public string UserCreateId { get; private set; } = string.Empty; 
    public User? UserCreate { get; set; }
    public Guid PaymentMethodId { get; private set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public Guid AccountId { get; private set; }
    public Account? Account { get; set; }

    private AccountTransaction() { }

    public AccountTransaction(decimal? totalPrice, TypeTransaction type, StatusAccountTransaction status, string? description, string userCreateId, Guid paymentMethodId, Guid accountId)
    {
        if (!totalPrice.HasValue || totalPrice <= 0)
            throw new AgroFileDomainException(MessagesAccountTransactionAgroFileDomain.TotalPriceIsRequired);

        if (!Enum.IsDefined(typeof(TypeTransaction), type))
            throw new AgroFileDomainException(MessagesAccountTransactionAgroFileDomain.InvalidTypeTransaction);

        if (!Enum.IsDefined(typeof(StatusAccountTransaction), status))
            throw new AgroFileDomainException(MessagesAccountTransactionAgroFileDomain.InvalidStatusAccountTransaction);

        TotalPrice = totalPrice;
        Type = type;
        Status = status;
        Description = description;
        UserCreateId = userCreateId;
        PaymentMethodId = paymentMethodId;
        AccountId = accountId;
    }

    public static AccountTransaction Create(decimal? totalPrice, TypeTransaction type, StatusAccountTransaction status, string? description, string userCreateId, Guid paymentMethodId, Guid accountId)
    {
        return new AccountTransaction(totalPrice, type, status, description, userCreateId, paymentMethodId, accountId);
    }
}