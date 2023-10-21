using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class TallaConfiguration : IEntityTypeConfiguration<Talla>
{
    public void Configure(EntityTypeBuilder<Talla> builder)
    {
        builder.ToTable("Talla");

        builder.HasKey(e => e.Id);
        builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(f => f.Descripcion)
            .IsRequired()
            .HasColumnName("Descripcion")
            .HasComment("Descripcion de la talla")
            .HasColumnType("varchar")
            .HasMaxLength(150);
    }
}