using AgroFile.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroFile.Infrastructure.EntitiesConfiguration; 

internal class PlotConfiguration : IEntityTypeConfiguration<Plot>
{
    public void Configure(EntityTypeBuilder<Plot> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UniqueIdentifier)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Area)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.SoilType)
            .IsRequired();
    }
}
