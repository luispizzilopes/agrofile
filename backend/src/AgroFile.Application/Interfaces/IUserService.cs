using AgroFile.Application.Dtos.User;
using AgroFile.Shared.Common;
using AgroFile.Shared.InputModels.User;

namespace AgroFile.Application.Interfaces;

public interface IUserService
{
    Task<PaginedResult<UserSummaryDTO>> GetUsers(PaginationParamsUserInputModel parameters);
    Task<UserSummaryDTO> GetUser(string id);
    Task<Result> CreateUser(UserDTO user);
    Task<Result> UpdateUser(UserDTO user);
    Task<Result> DeleteUser(string id); 
}
