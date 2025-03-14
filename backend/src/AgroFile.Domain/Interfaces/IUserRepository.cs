﻿using AgroFile.Domain.Common;
using AgroFile.Domain.Entities;

namespace AgroFile.Domain.Interfaces; 

public interface IUserRepository
{
    Task<PaginedResult<User>> GetUsers(PaginationParams parameters);
    Task<User> GetUser(string id);
    Task<bool> CreateUser(User user, string password);
    Task<bool> UpdateUser(User user);
    Task<bool> DeleteUser(User user); 
}
