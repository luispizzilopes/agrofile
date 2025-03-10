using AgroFile.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroFile.Infrastructure.EntitiesConfiguration;

internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.MiddleName)
            .HasMaxLength(50);

        builder.Property(x => x.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.IndividualRegistration)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Wage)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Address)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.JobTitle)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.HireDate)
            .IsRequired();

        builder.Property(x => x.TerminationDate);

        builder.Property(x => x.BirthdayDate);

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasOne(x => x.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Manager)
            .WithMany()
            .HasForeignKey(x => x.ManagerId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
