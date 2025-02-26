namespace AgroFile.Domain.Entities.Base; 

public class BaseEntity
{
    public Guid Id { get; set; }
    public string? CreateIpClient { get; set; }
    public string? UpdateIpClient { get; set; }
    public DateTimeOffset? CreateTime { get; set; }
    public DateTimeOffset? UpdateTime { get; set; }
}
