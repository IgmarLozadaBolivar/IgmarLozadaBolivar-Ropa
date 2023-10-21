using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
{
    public void Configure(EntityTypeBuilder<DetalleOrden> builder)
    {
        builder.ToTable("DetalleOrden");

        builder.HasKey(e => e.Id);
        builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(f => f.CantidadProduccir)
            .IsRequired()
            .HasColumnName("CantidadProduccir")
            .HasComment("Cantidad a producir")
            .HasColumnType("int");

        builder.Property(f => f.CantidadProducida)
            .IsRequired()
            .HasColumnName("CantidadProducida")
            .HasComment("Cantidad ya producida")
            .HasColumnType("int");

        builder.HasOne(p => p.Orden)
            .WithMany(p => p.DetalleOrdens)
            .HasForeignKey(p => p.IdOrdenFK);

        builder.HasOne(p => p.Prenda)
            .WithMany(p => p.DetalleOrdens)
            .HasForeignKey(p => p.IdPrendaFK);

        builder.HasOne(p => p.Color)
            .WithMany(p => p.DetalleOrdens)
            .HasForeignKey(p => p.IdColorFK);

        builder.HasOne(p => p.Estado)
            .WithMany(p => p.DetalleOrdens)
            .HasForeignKey(p => p.IdEstadoFK);
    }
}