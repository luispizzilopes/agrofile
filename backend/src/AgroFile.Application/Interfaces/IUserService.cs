using AgroFile.Application.Dtos.User;
using AgroFile.Domain.Common;

namespace AgroFile.Application.Interfaces;

public interface IUserService
{
    Task<PaginedResult<UserSummaryDTO>> GetUsers(PaginationParams parameters);
    Task<UserSummaryDTO> GetUser(string id);
    Task<Result> CreateUser(UserDTO user);
    Task<Result> UpdateUser(UserDTO user);
    Task<Result> DeleteUser(string id); 
}
