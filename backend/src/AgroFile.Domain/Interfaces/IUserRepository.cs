using AgroFile.Domain.Entities;
using AgroFile.Shared.Common;
using AgroFile.Shared.InputModels.User;

namespace AgroFile.Domain.Interfaces; 

public interface IUserRepository
{
    Task<PaginedResult<User>> GetUsers(PaginationParamsUserInputModel parameters);
    Task<User> GetUser(string id);
    Task<User> GetUserByEmail(string email); 
    Task<bool> CreateUser(User user, string password);
    Task<bool> UpdateUser(User user);
    Task<bool> DeleteUser(string id);

    Task<bool> UserEmailExists(string email); 
}
