using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamento");

        builder.HasKey(e => e.Id);
        builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(f => f.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasComment("Nombre del departamento")
            .HasColumnType("varchar")
            .HasMaxLength(50);
    
        builder.HasOne(p => p.Pais)
            .WithMany(p => p.Departamentos)
            .HasForeignKey(p => p.IdPaisFK);
    }
}