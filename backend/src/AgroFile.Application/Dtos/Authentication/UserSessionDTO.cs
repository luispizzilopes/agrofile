using AgroFile.Application.Dtos.TokenJwt;

namespace AgroFile.Application.Dtos.Authentication;

public class UserSessionDTO
{
    public string? Id { get; set; }
    public string? Email { get; set; }
    public TokenJwtInformationDTO? TokenJwtInformation { get; set; }

    public UserSessionDTO() { }

    public UserSessionDTO(string? id, string? email, TokenJwtInformationDTO? tokenJwtInformation)
    {
        Id = id;
        Email = email;
        TokenJwtInformation = tokenJwtInformation;
    }
}
