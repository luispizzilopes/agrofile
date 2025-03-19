namespace AgroFile.Application.Dtos.User; 

public class UserSummaryDTO
{   
    public string Id { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Picture { get; set; } 
}
