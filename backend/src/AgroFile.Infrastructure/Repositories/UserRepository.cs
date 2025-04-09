using AgroFile.Domain.Common;
using AgroFile.Domain.Entities;
using AgroFile.Domain.Interfaces;
using AgroFile.Infrastructure.Context;
using AgroFile.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AgroFile.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;

    public UserRepository(AppDbContext context, UserManager<User> userManager)
    {
        _userManager = userManager; 
        _context = context;
    }

    public async Task<User> GetUser(string id)
    {
        return await _context.Users
            .AsNoTracking()
            .AsQueryable() 
            .FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new KeyNotFoundException("Não foi possível encontrar um usuario com o Id informado."); 
    }
    public async Task<User> GetUserByEmail(string email)
    {
        return await _context.Users
            .AsNoTracking()
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.Email == email)
            ?? throw new KeyNotFoundException("Não foi possível encontrar um usuario com o e-mail informado.");
    }

    public async Task<PaginedResult<User>> GetUsers(PaginationParams parameters)
    {
        return await _context.Users
            .AsNoTracking()
            .Select(u => new User
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName,
                Picture = u.Picture,
                LockoutEnabled = u.LockoutEnabled,
            })
            .PaginationAsync(parameters); 
    }

    public async Task<bool> CreateUser(User user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);
        return result.Succeeded; 
    }

    public async Task<bool> UpdateUser(User user)
    {
        var existingUser = await _userManager.FindByIdAsync(user.Id);

        _context.Users.Entry(existingUser!).CurrentValues.SetValues(user);

        var result = await _userManager.UpdateAsync(existingUser!);
        return result.Succeeded;
    }

    public async Task<bool> DeleteUser(string id)
    {
        var user = await GetUser(id); 
        var result = await _userManager.DeleteAsync(user);
        return result.Succeeded;
    }

    public async Task<bool> UserEmailExists(string email)
    {
        return await _context.Users
            .Where(u => u.Email == email)
            .AnyAsync(); 
    }
}
