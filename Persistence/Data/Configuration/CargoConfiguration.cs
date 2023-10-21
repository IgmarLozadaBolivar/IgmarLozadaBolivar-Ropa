using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
{
    public void Configure(EntityTypeBuilder<Cargo> builder)
    {
        builder.ToTable("Cargo");

        builder.HasKey(e => e.Id);
        builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(f => f.Descripcion)
            .IsRequired()
            .HasColumnName("Descripcion")
            .HasComment("Descripcion del cargo")
            .HasColumnType("varchar")
            .HasMaxLength(150);

        builder.Property(f => f.SueldoBase)
            .IsRequired()
            .HasColumnName("SueldoBase")
            .HasComment("Sueldo base del cargo")
            .HasColumnType("int");
    }
}