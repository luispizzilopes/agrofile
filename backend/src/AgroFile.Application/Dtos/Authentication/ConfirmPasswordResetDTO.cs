namespace AgroFile.Application.Dtos.Authentication; 

public class ConfirmPasswordResetDTO
{
    public string Token { get; set; } = string.Empty; 
    public string Email { get; set; } = string.Empty; 

    public ConfirmPasswordResetDTO() { }

    public ConfirmPasswordResetDTO(string token, string email)
    {
        Token = token;
        Email = email;
    }
}
