using AgroFile.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AgroFile.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using AgroFile.Domain.Interfaces;
using AgroFile.Infrastructure.Repositories;
using AgroFile.Application.Interfaces;
using AgroFile.Application.Services;
using AgroFile.Application.Interfaces.Validators;
using AgroFile.Application.Validators; 

namespace AgroFile.CrossCutting.IoC; 

public static class DependencyInjection
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {                                   
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }

    public static IServiceCollection AddIdentityUser(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedEmail = true;
        })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

        return services; 
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

        return services; 
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<ITokenJwtService, TokenJwtService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<ITemplateService, TemplateService>();

        return services; 
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IUserValidator, UserValidator>();
        services.AddScoped<IAuthenticationValidator, AuthenticationValidator>();

        return services; 
    }
}
