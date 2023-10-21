namespace Domain.Entities;

public class Insumo : BaseEntity
{
    public string Nombre { get; set; }
    public decimal ValorUnit { get; set; }
    public int StockMin { get; set; }
    public int StockMax { get; set; }
    public ICollection<Proveedor> Proveedors { get; set; } = new HashSet<Proveedor>();
    public ICollection<Prenda> Prendas { get; set; } = new HashSet<Prenda>();
    public ICollection<InsumoPrenda> InsumoPrendas { get; set; } = new HashSet<InsumoPrenda>();
    public ICollection<InsumoProveedor> InsumoProveedors { get; set; }
}