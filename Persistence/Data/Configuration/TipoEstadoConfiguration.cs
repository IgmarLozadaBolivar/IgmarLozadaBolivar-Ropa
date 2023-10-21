using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class TipoEstadoConfiguration : IEntityTypeConfiguration<TipoEstado>
{
    public void Configure(EntityTypeBuilder<TipoEstado> builder)
    {
        builder.ToTable("TipoEstado");

        builder.HasKey(e => e.Id);
        builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(f => f.Descripcion)
            .IsRequired()
            .HasColumnName("Descripcion")
            .HasComment("Descripcion del tipo de estado")
            .HasColumnType("varchar")
            .HasMaxLength(150);
    }
}