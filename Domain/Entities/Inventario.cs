namespace Domain.Entities;

public class Inventario : BaseEntity
{
    public int CodInv { get; set; }
    public int IdPrendaFK { get; set; }
    public Prenda Prenda { get; set; }
    public decimal ValorVtaCOP { get; set; }
    public decimal ValorVtaUSD { get; set; }
    public ICollection<Talla> Tallas { get; set; }
    public ICollection<InventarioTalla> InventarioTallas { get; set; } = new HashSet<InventarioTalla>();
    public ICollection<DetalleVenta> DetalleVentas { get; set; }  = new HashSet<DetalleVenta>();
}