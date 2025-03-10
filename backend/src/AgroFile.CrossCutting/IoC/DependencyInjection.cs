using AgroFile.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AgroFile.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AgroFile.CrossCutting.IoC; 

public static class DependencyInjection
{
    public static IServiceCollection AddDependecyInjection(this IServiceCollection services, IConfiguration configuration)
    {                                   
        services.AddHttpContextAccessor();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddIdentity<User, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedEmail = true;
        })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}
