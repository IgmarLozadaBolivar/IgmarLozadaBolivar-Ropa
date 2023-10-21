using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
{
    public void Configure(EntityTypeBuilder<Inventario> builder)
    {
        builder.ToTable("Inventario");

        builder.HasKey(e => e.Id);
        builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(f => f.CodInv)
            .IsRequired()
            .HasColumnName("CodInv")
            .HasComment("Codigo unico del inventario")
            .HasColumnType("int");

        builder.Property(f => f.ValorVtaCOP)
            .IsRequired()
            .HasColumnName("ValorVtaCOP")
            .HasComment("Valor de venta del inventario en Pesos Colombia");

        builder.Property(f => f.ValorVtaUSD)
            .IsRequired()
            .HasColumnName("ValorVtaUSD")
            .HasComment("Valor de venta del inventario en Dolares Estadounidenses");

        builder.HasOne(p => p.Prenda)
            .WithMany(p => p.Inventarios)
            .HasForeignKey(p => p.IdPrendaFK);

        builder.HasMany(p => p.Tallas)
            .WithMany(r => r.Inventarios)
            .UsingEntity<InventarioTalla>(

                j => j
                    .HasOne(pt => pt.Talla)
                    .WithMany(t => t.InventarioTallas)
                    .HasForeignKey(ut => ut.IdTallaFK),


                j => j
                    .HasOne(et => et.Inventario)
                    .WithMany(et => et.InventarioTallas)
                    .HasForeignKey(el => el.IdInventarioFK),

                j =>
                {
                    j.ToTable("InventarioTalla");
                    j.HasKey(t => new { t.IdInventarioFK, t.IdTallaFK });

                    j.Property(t => t.Cantidad)
                        .IsRequired()
                        .HasColumnName("Cantidad")
                        .HasComment("Cantidad del inventario en tallas")
                        .HasColumnType("int");
                });
    }
}