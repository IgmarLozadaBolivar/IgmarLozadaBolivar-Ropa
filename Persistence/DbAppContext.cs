using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Persistence;

public class DbAppContext : DbContext
{
    public DbAppContext(DbContextOptions<DbAppContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<UserRol> UserRols { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Cargo> Cargos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<DetalleOrden> DetalleOrdens { get; set; }
    public DbSet<DetalleVenta> DetalleVentas { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<FormaPago> FormaPagos { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<Insumo> Insumos { get; set; }
    public DbSet<InsumoPrenda> InsumoPrendas { get; set; }
    public DbSet<InsumoProveedor> InsumoProveedors { get; set; }
    public DbSet<Inventario> Inventarios { get; set; }
    public DbSet<InventarioTalla> InventarioTallas { get; set; }
    public DbSet<Municipio> Municipios { get; set; }
    public DbSet<Orden> Ordens { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<Prenda> Prendas { get; set; }
    public DbSet<Proveedor> Proveedors { get; set; }
    public DbSet<Talla> Tallas { get; set; }
    public DbSet<TipoEstado> TipoEstados { get; set; }
    public DbSet<TipoPersona> TipoPersonas { get; set; }
    public DbSet<TipoProteccion> TipoProteccions { get; set; }
    public DbSet<Venta> Ventas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empresa>().HasIndex(e => e.Nit).IsUnique();
        modelBuilder.Entity<Prenda>().HasIndex(p => p.IdPrenda).IsUnique();
        modelBuilder.Entity<Insumo>().HasIndex(i => i.Nombre).IsUnique();
        modelBuilder.Entity<Proveedor>().HasIndex(pv => pv.NitProveedor).IsUnique();
        modelBuilder.Entity<Empleado>().HasIndex(ep => ep.IdEmpleado).IsUnique();
        modelBuilder.Entity<Inventario>().HasIndex(iv => iv.CodInv).IsUnique();
        modelBuilder.Entity<Talla>().HasIndex(t => t.Descripcion).IsUnique();
        modelBuilder.Entity<Cliente>().HasIndex(c => c.IdCliente).IsUnique();

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}