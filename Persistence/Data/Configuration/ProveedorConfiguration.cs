using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("Proveedor");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(f => f.NitProveedor)
            .IsRequired()
            .HasColumnName("NitProveedor")
            .HasComment("Nit del proveedor")
            .HasColumnType("int")
            .HasMaxLength(9);

        builder.Property(f => f.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasComment("Nombre del proveedor")
            .HasColumnType("varchar")
            .HasMaxLength(50);

        builder.HasOne(p => p.TipoPersona)
            .WithMany(p => p.Proveedors)
            .HasForeignKey(p => p.IdTipoPersonaFK);

        builder.HasOne(p => p.Municipio)
            .WithMany(p => p.Proveedors)
            .HasForeignKey(p => p.IdMunicipioFK);
    }
}