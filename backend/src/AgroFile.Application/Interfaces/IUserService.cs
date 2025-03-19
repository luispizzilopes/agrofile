using AgroFile.Application.Dtos.User;
using AgroFile.Domain.Common;

namespace AgroFile.Application.Interfaces;

public interface IUserService
{
    Task<PaginedResult<UserSummaryDTO>> GetUsers(PaginationParams parameters);
    Task<UserSummaryDTO> GetUser(string id);
    Task<bool> CreateUser(UserDTO user);
    Task<bool> UpdateUser(UserDTO user);
    Task<bool> DeleteUser(string id); 
}
