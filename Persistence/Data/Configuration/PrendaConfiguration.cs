using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
{
    public void Configure(EntityTypeBuilder<Prenda> builder)
    {
        builder.ToTable("Prenda");

        builder.HasKey(e => e.Id);
        builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(f => f.IdPrenda)
            .IsRequired()
            .HasColumnName("IdPrenda")
            .HasComment("Id unico de prenda")
            .HasColumnType("int")
            .HasMaxLength(9);

        builder.Property(f => f.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasComment("Nombre de la prenda")
            .HasColumnType("varchar")
            .HasMaxLength(50);

        builder.Property(f => f.ValorUnitCOP)
            .IsRequired()
            .HasColumnName("ValorUnitCOP")
            .HasComment("Valor unitario de la prenda en Pesos Colombianos");

        builder.Property(f => f.ValorUnitUSD)
            .IsRequired()
            .HasColumnName("ValorUnitUSD")
            .HasComment("Valor unitario de la prenda en Dolares Estadounidenses");

        builder.HasOne(p => p.Estado)
            .WithMany(p => p.Prendas)
            .HasForeignKey(p => p.IdEstadoFK);

        builder.HasOne(p => p.TipoProteccion)
            .WithMany(p => p.Prendas)
            .HasForeignKey(p => p.IdTipoProteccionFK);

        builder.HasOne(p => p.Genero)
            .WithMany(p => p.Prendas)
            .HasForeignKey(p => p.IdGeneroFK);
    }
}