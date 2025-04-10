using AgroFile.Application.Dtos.User;
using AgroFile.Domain.Common;
using AgroFile.Shared.Common;

namespace AgroFile.Application.Interfaces.Validators;

public interface IUserValidator
{
    Task<Result> ValidateCreateUser(UserDTO user); 
    Task<Result> ValidateUpdateUser(UserDTO user); 
}
