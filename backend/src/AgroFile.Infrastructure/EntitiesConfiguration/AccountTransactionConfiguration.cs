using AgroFile.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroFile.Infrastructure.EntitiesConfiguration; 

internal class AccountTransactionConfiguration : IEntityTypeConfiguration<AccountTransaction>
{
    public void Configure(EntityTypeBuilder<AccountTransaction> builder)
    {
        builder.HasKey(x => x.Id); 

        builder.Property(x => x.TotalPrice)
           .HasColumnType("decimal(18,2)")
           .IsRequired();

        builder.Property(x => x.Type)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.TransactionDate)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(1000);

        builder.HasOne(x => x.UserCreate)
            .WithMany(x => x.AccountTransactions)
            .IsRequired()
            .OnDelete(DeleteBehavior.SetNull); 

        builder.HasOne(x => x.PaymentMethod)
            .WithMany(x => x.AccountTransactions)
            .IsRequired()
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Account)
            .WithMany(x => x.AccountTransactions)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
