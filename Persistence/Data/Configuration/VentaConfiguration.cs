using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("Venta");

        builder.HasKey(e => e.Id);
        builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(f => f.Fecha)
            .IsRequired()
            .HasColumnName("Fecha")
            .HasComment("Fecha de la venta");

        builder.HasOne(p => p.Empleado)
            .WithMany(p => p.Ventas)
            .HasForeignKey(p => p.IdEmpleadoFK);

        builder.HasOne(p => p.Cliente)
            .WithMany(p => p.Ventas)
            .HasForeignKey(p => p.IdClienteFK);

        builder.HasOne(p => p.FormaPago)
            .WithMany(p => p.Ventas)
            .HasForeignKey(p => p.IdFormaPagoFK);
    }
}