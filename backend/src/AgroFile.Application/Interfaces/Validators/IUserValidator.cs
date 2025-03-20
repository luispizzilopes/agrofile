using AgroFile.Application.Dtos.User;

namespace AgroFile.Application.Interfaces.Validators;

public interface IUserValidator
{
    Task ValidateUser(UserDTO user); 
}
