
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("Empleado");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(f => f.IdEmpleado)
            .IsRequired()
            .HasColumnName("IdEmpleado")
            .HasComment("Id unico del empleado")
            .HasColumnType("int")
            .HasMaxLength(9);

        builder.Property(f => f.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasComment("Nombre del empleado")
            .HasColumnType("varchar")
            .HasMaxLength(50);

        builder.Property(f => f.FechaIngreso)
            .IsRequired()
            .HasColumnName("FechaIngreso")
            .HasComment("Fecha de ingreso del empleado");

        builder.HasOne(p => p.Cargo)
            .WithMany(p => p.Empleados)
            .HasForeignKey(p => p.IdCargoFK);

        builder.HasOne(p => p.Municipio)
            .WithMany(p => p.Empleados)
            .HasForeignKey(p => p.IdMunicipioFK);
    }
}