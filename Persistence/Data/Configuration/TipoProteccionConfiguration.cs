using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class TipoProteccionConfiguration : IEntityTypeConfiguration<TipoProteccion>
{
    public void Configure(EntityTypeBuilder<TipoProteccion> builder)
    {
        builder.ToTable("TipoProteccion");

        builder.HasKey(e => e.Id);
        builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(f => f.Descripcion)
            .IsRequired()
            .HasColumnName("Descripcion")
            .HasComment("Descripcion del tipo de proteccion")
            .HasColumnType("varchar")
            .HasMaxLength(150);
    }
}