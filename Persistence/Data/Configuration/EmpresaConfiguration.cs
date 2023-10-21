using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("Empresa");

        builder.HasKey(e => e.Id);
        builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(f => f.Nit)
            .IsRequired()
            .HasColumnName("Nit")
            .HasComment("Nit de la empresa")
            .HasColumnType("int")
            .HasMaxLength(9);

        builder.Property(f => f.RazonSocial)
            .IsRequired()
            .HasColumnName("RazonSocial")
            .HasComment("Razon social de la empresa")
            .HasColumnType("varchar")
            .HasMaxLength(50);

        builder.Property(f => f.RepresentanteLegal)
            .IsRequired()
            .HasColumnName("RepresentanteLegal")
            .HasComment("Representante legal de la empresa")
            .HasColumnType("varchar")
            .HasMaxLength(50);

        builder.Property(f => f.FechaCreacion)
            .IsRequired()
            .HasColumnName("FechaCreacion")
            .HasComment("Fecha de creacion de la empresa");

        builder.HasOne(p => p.Municipio)
            .WithMany(p => p.Empresas)
            .HasForeignKey(p => p.IdMunicipioFK);
    }
}