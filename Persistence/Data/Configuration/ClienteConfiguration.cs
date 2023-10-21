using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");

        builder.HasKey(e => e.Id);
        builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(f => f.IdCliente)
            .IsRequired()
            .HasColumnName("IdCliente")
            .HasComment("Id unico del cliente")
            .HasColumnType("int")
            .HasMaxLength(9);

        builder.Property(f => f.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasComment("Nombre del cliente")
            .HasColumnType("varchar")
            .HasMaxLength(50);

        builder.Property(f => f.FechaRegistro)
            .IsRequired()
            .HasColumnName("FechaRegistro")
            .HasComment("Fecha de registro del cliente");

        builder.HasOne(p => p.TipoPersona)
            .WithMany(p => p.Clientes)
            .HasForeignKey(p => p.IdTipoPersonaFK);

        builder.HasOne(p => p.Municipio)
            .WithMany(p => p.Clientes)
            .HasForeignKey(p => p.IdMunicipioFK);
    }
}