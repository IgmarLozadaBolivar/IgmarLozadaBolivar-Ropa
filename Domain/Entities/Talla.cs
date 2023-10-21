namespace Domain.Entities;

public class Talla : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<Inventario> Inventarios { get; set; }
    public ICollection<InventarioTalla> InventarioTallas { get; set; } = new HashSet<InventarioTalla>();
    public ICollection<DetalleVenta> DetalleVentas { get; set; } = new HashSet<DetalleVenta>();
}