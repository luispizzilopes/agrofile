using AgroFile.Domain.Common;
using AgroFile.Domain.Enum;

namespace AgroFile.Domain.Entities; 

public class Account : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string SubTitle { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public AccountType Type { get; set; }
    public int AccountCategoryId { get; set; }
    public AccountCategory? Category { get; set; }
}
