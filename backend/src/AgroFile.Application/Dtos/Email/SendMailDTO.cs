namespace AgroFile.Application.Dtos.Email;

public class SendMailDTO
{
    public string SendTo { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsBodyHtml { get; set; } = true;
}
