using AgroFile.Domain.Common;
using AgroFile.Domain.Enum;

namespace AgroFile.Domain.Entities;
public class AccountTransaction : BaseEntity
{
    public decimal? TotalPrice { get; set; }
    public StatusAccountTransaction Status { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public string? Description { get; set; }

    public Guid UserCreateId { get; set; }
    public User? UserCreate { get; set; }
    public Guid PaymentMethodId { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public Guid AccountId { get; set; }
    public Account? Account { get; set; }
}
