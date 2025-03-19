using AgroFile.Domain.Entities;
using AgroFile.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AgroFile.Infrastructure.Repositories; 

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly SignInManager<User> _signInManager;

    public AuthenticationRepository(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<bool> PasswordSignIn(string email, string password)
    {
        var result = await _signInManager
            .PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);

        return result.Succeeded;
    }
}
