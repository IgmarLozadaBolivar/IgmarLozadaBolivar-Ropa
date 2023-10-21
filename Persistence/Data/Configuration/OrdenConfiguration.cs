using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
{
    public void Configure(EntityTypeBuilder<Orden> builder)
    {
        builder.ToTable("Orden");

        builder.HasKey(e => e.Id);
        builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(f => f.Fecha)
            .IsRequired()
            .HasColumnName("Fecha")
            .HasComment("Fecha de la orden");

        builder.HasOne(p => p.Empleado)
            .WithMany(p => p.Ordens)
            .HasForeignKey(p => p.IdEmpleadoFK);

        builder.HasOne(p => p.Cliente)
            .WithMany(p => p.Ordens)
            .HasForeignKey(p => p.IdClienteFK);

        builder.HasOne(p => p.Estado)
            .WithMany(p => p.Ordens)
            .HasForeignKey(p => p.IdEstadoFK);
    }
}