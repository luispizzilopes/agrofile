using AgroFile.Domain.Entities.Base;

namespace AgroFile.Domain.Entities; 

public class YearManagement : BaseEntity
{
    public int Year { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public bool Open { get; set; }
}
