using AgroFile.Domain.Entities.Base;

namespace AgroFile.Domain.Entities; 

public class Plot : BaseEntity
{
    public string UniqueIdentifier { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty; 
    public decimal Area { get; set; }
    public int SoilType { get; set; }
    public Guid EstateId { get; set; }
}