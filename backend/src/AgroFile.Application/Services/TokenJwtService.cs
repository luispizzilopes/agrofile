using AgroFile.Application.Consts;
using AgroFile.Application.Dtos.TokenJwt;
using AgroFile.Application.Interfaces;
using AgroFile.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AgroFile.Application.Services;

public class TokenJwtService : ITokenJwtService
{
    private readonly IConfiguration _configuration; 

    public TokenJwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TokenJwtInformationDTO CreateTokenUser(User user)
    {
        TokenJwtInformationDTO tokenJwtInformation = new();

        AssigningToken(tokenJwtInformation, user); 

        return tokenJwtInformation;
    }

    private void AssigningToken(TokenJwtInformationDTO tokenJwtInformation, User user) 
    {
        JwtSecurityTokenHandler handler = new();

        tokenJwtInformation.Token = handler.WriteToken(CreateJwtSecurityToken(user));
        tokenJwtInformation.DateExpiration = CreateExpirationDate(); 
    }

    private JwtSecurityToken CreateJwtSecurityToken(User user)
    {
        Claim[] claims = CreateUserClaims(user);
        SigningCredentials signingCredentials = CreateSigningCredentials();
        DateTime expirationDate = CreateExpirationDate();

        return new JwtSecurityToken(
              issuer: _configuration["TokenConfiguration:Issuer"],
              audience: _configuration["TokenConfiguration:Audience"],
              claims: claims,
              expires: expirationDate,
              signingCredentials: signingCredentials);
    }

    private Claim[] CreateUserClaims(User user)
    {
        Claim[] claims =
        {
            new Claim(AgroFIleClaimsNames.UserId, user.Id), 
            new Claim(AgroFIleClaimsNames.UserName, user.UserName ?? string.Empty) 
        };

        return claims; 
    }

    private SigningCredentials CreateSigningCredentials()
    {
        byte[] secretKeyEncoding = Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!);
        SymmetricSecurityKey symmetricKey = new SymmetricSecurityKey(secretKeyEncoding);
        return new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256); 
    }

    private DateTime CreateExpirationDate()
    {
        var hoursExpiration = double.Parse(_configuration["TokenConfiguration:ExpireHours"]!);
        return DateTime.Now.AddHours(hoursExpiration);
    }
}
