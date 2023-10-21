using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {
        builder.ToTable("DetalleVenta");

        builder.HasKey(e => e.Id);
        builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(f => f.Cantidad)
            .IsRequired()
            .HasColumnName("Cantidad")
            .HasComment("Cantidad del detalle de venta")
            .HasColumnType("int");

        builder.Property(f => f.ValorUnit)
            .IsRequired()
            .HasColumnName("ValorUnit")
            .HasComment("Valor unitario del detalle de venta");

        builder.HasOne(p => p.Venta)
            .WithMany(p => p.DetalleVentas)
            .HasForeignKey(p => p.IdVentaFK);

        builder.HasOne(p => p.Inventario)
            .WithMany(p => p.DetalleVentas)
            .HasForeignKey(p => p.IdProductoFK);

        builder.HasOne(p => p.Talla)
            .WithMany(p => p.DetalleVentas)
            .HasForeignKey(p => p.IdTallaFK);
    }
}