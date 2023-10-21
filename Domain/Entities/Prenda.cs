namespace Domain.Entities;

public class Prenda : BaseEntity
{
    public int IdPrenda { get; set; }
    public string Nombre { get; set; }
    public decimal ValorUnitCOP { get; set; }
    public decimal ValorUnitUSD { get; set; }
    public int IdEstadoFK { get; set; }
    public Estado Estado { get; set; }
    public int IdTipoProteccionFK { get; set; }
    public TipoProteccion TipoProteccion { get; set; }
    public int IdGeneroFK { get; set; }
    public Genero Genero { get; set; }
    public ICollection<Insumo> Insumos { get; set; } = new HashSet<Insumo>();
    public ICollection<InsumoPrenda> InsumoPrendas { get; set; } = new HashSet<InsumoPrenda>();
    public ICollection<Inventario> Inventarios { get; set; }
    public ICollection<DetalleOrden> DetalleOrdens { get; set; }
}