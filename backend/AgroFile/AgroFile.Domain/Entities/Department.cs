using AgroFile.Domain.Entities.Base;

namespace AgroFile.Domain.Entities; 

public class Department : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty; 
}
