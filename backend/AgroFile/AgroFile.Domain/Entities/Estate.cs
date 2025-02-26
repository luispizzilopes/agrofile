using AgroFile.Domain.Entities.Base;

namespace AgroFile.Domain.Entities; 

public class Estate : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Address { get; set; } 
    public string? City { get; set; } 
    public string? State { get; set; } 
    public string? Coutry { get; set; } 

    public IEnumerable<Plot>? Plots { get; set; }
}
