namespace Domain.Entities;

public class Insumo : BaseEntity
{
    public string Nombre { get; set; }
    public decimal ValorUnit { get; set; }
    public int StockMin { get; set; }
    public int StockMax { get; set; }
    public ICollection<InsumoPrenda> InsumoPrendas { get; set; } = new HashSet<InsumoPrenda>();
    public ICollection<InsumoProveedor> InsumoProveedors { get; set; } = new HashSet<InsumoProveedor>();
}