using System.ComponentModel.DataAnnotations;

namespace AgroFile.Application.Dtos.Authentication; 

public class PasswordResetDTO
{
    [EmailAddress(ErrorMessage = "O endereço de e-mail não é válido!")]
    [Required(ErrorMessage = "O campo 'e-mail' é obrigatório")]
    public string Email { get; set; } = string.Empty;
}
