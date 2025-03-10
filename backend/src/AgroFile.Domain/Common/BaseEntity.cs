namespace AgroFile.Domain.Common;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid(); 
    public string? CreateIpClient { get; set; }
    public string? UpdateIpClient { get; set; }
    public DateTimeOffset? CreateTime { get; set; }
    public DateTimeOffset? UpdateTime { get; set; }
}
