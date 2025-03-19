using System.ComponentModel.DataAnnotations;

namespace AgroFile.Application.Dtos.Authentication; 

public class LoginDTO
{
    [EmailAddress(ErrorMessage = "O endereço de e-mail não é válido!")]
    [Required(ErrorMessage = "O campo 'e-mail' é obrigatório")]
    [MaxLength(255, ErrorMessage = "O campo 'e-email' deve conter no máximo 255 caracteres")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo 'senha' é obrigatório")]
    public string Password { get; set; } = string.Empty; 
}
