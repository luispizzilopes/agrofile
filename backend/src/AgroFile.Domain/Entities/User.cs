using Microsoft.AspNetCore.Identity;

namespace AgroFile.Domain.Entities; 

public class User : IdentityUser
{
    public string? Picture { get; set; }
    public bool? Active { get; set; }

    public ICollection<AccountTransaction>? AccountTransactions { get; set; }
}
