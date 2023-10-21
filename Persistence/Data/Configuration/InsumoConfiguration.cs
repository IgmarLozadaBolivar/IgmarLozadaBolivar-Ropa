using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
{
    public void Configure(EntityTypeBuilder<Insumo> builder)
    {
        builder.ToTable("Insumo");

        builder.HasKey(e => e.Id);
        builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(f => f.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasComment("Nombre del insumo")
            .HasColumnType("varchar")
            .HasMaxLength(50);

        builder.Property(f => f.ValorUnit)
            .IsRequired()
            .HasColumnName("ValorUnit")
            .HasComment("Valor unitario del insumo")
            .HasColumnType("int");

        builder.Property(f => f.StockMin)
            .IsRequired()
            .HasColumnName("StockMin")
            .HasComment("Stock minimo del insumo")
            .HasColumnType("int");

        builder.Property(f => f.StockMax)
            .IsRequired()
            .HasColumnName("StockMax")
            .HasComment("Stock maximo del insumo")
            .HasColumnType("int");

        builder.HasMany(p => p.Proveedors)
            .WithMany(r => r.Insumos)
            .UsingEntity<InsumoProveedor>(

                j => j
                    .HasOne(pt => pt.Proveedor)
                    .WithMany(t => t.InsumoProveedors)
                    .HasForeignKey(ut => ut.IdProveedorFK),


                j => j
                    .HasOne(et => et.Insumo)
                    .WithMany(et => et.InsumoProveedors)
                    .HasForeignKey(el => el.IdInsumoFK),

                j =>
                {
                    j.ToTable("InsumoProveedor");
                    j.HasKey(t => new { t.IdInsumoFK, t.IdProveedorFK });

                });

        builder.HasMany(p => p.Prendas)
            .WithMany(r => r.Insumos)
            .UsingEntity<InsumoPrenda>(

                j => j
                    .HasOne(pt => pt.Prenda)
                    .WithMany(t => t.InsumoPrendas)
                    .HasForeignKey(ut => ut.IdInsumoFK),


                j => j
                    .HasOne(et => et.Insumo)
                    .WithMany(et => et.InsumoPrendas)
                    .HasForeignKey(el => el.IdPrendaFK),

                j =>
                {
                    j.ToTable("InsumoPrenda");
                    j.HasKey(t => new { t.IdInsumoFK, t.IdPrendaFK });

                    j.Property(t => t.Cantidad)
                        .IsRequired()
                        .HasColumnName("Cantidad")
                        .HasComment("Cantidad del insumo de prendas")
                        .HasColumnType("int");
                });
    }
}