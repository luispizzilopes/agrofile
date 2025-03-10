using AgroFile.Domain.Common;
using AgroFile.Domain.Entities;

namespace AgroFile.Domain.Interfaces; 

public interface IUserRepository
{
    Task<PaginedResult<User>> GetUsers(PaginationParams parameters);
    Task<Department> GetUser(Guid id);
    Task<Department> CreateUser(User user);
    Task<Department> UpdateUser(User user);
    Task<bool> DeleteUser(User user); 
}
