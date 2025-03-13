using AgroFile.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroFile.Infrastructure.EntitiesConfiguration; 

internal class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.SubTitle)
           .HasMaxLength(200)
           .IsRequired();

        builder.Property(x => x.OpeningBalance)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasOne(x => x.AccountCategory)
            .WithMany(x => x.Accounts)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict); 
    }
}
