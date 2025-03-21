namespace AgroFile.Domain.Interfaces;

public interface IAuthenticationRepository
{
    Task<bool> PasswordSignIn(string email, string password);
    Task<bool> EmailConfirmed(string email); 
}
