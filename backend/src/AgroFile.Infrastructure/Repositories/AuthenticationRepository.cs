using AgroFile.Domain.Entities;
using AgroFile.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AgroFile.Infrastructure.Repositories; 

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public AuthenticationRepository(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<bool> EmailConfirmed(string email)
    {
        User? user = await _userManager.FindByEmailAsync(email);
        if (user is null) return false; 

        return await _userManager.IsEmailConfirmedAsync(user);
    }

    public async Task<bool> PasswordSignIn(string email, string password)
    {
        var result = await _signInManager
            .PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);

        return result.Succeeded;
    }


}
