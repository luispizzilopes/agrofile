using AgroFile.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgroFile.Infrastructure.Context;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Plot> Plots { get; set; }
    public DbSet<Estate> Estates { get; set; }
    public DbSet<YearManagement> YearsManagement { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountCategory> AccountCategories { get; set; }
    public DbSet<AccountTransaction> AccountTransactions { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly); 
    }
}
