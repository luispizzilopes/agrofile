using AgroFile.Application.Dtos.TokenJwt;
using AgroFile.Domain.Entities;

namespace AgroFile.Application.Interfaces; 

public interface ITokenJwtService
{
    TokenJwtInformationDTO CreateTokenUser(User user); 
}
