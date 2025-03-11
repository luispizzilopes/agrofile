using AgroFile.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AgroFile.Infrastructure.EntitiesConfiguration;

internal class EstateConfiguration : IEntityTypeConfiguration<Estate>
{
    public void Configure(EntityTypeBuilder<Estate> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.Address)
            .HasMaxLength(200);

        builder.Property(x => x.City)
            .HasMaxLength(200);

        builder.Property(x => x.State)
            .HasMaxLength(200);

        builder.Property(x => x.Coutry)
            .HasMaxLength(200);

        builder.HasMany(x => x.Plots)
            .WithOne(x => x.Estate)
            .HasForeignKey(x => x.EstateId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}