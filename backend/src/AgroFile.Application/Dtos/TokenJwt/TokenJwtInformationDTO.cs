namespace AgroFile.Application.Dtos.TokenJwt; 

public class TokenJwtInformationDTO
{
    public string? Token { get; set; }
    public DateTimeOffset? DateExpiration { get; set; }

    public TokenJwtInformationDTO() { }

    public TokenJwtInformationDTO(string? token, DateTimeOffset? dateExpiration)
    {
        Token = token;
        DateExpiration = dateExpiration;
    }
}
