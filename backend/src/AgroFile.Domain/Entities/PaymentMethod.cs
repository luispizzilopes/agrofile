using AgroFile.Domain.Common;

namespace AgroFile.Domain.Entities; 

public class PaymentMethod : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
