namespace Domain.Entities;

public class Estado : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<Prenda> Prendas { get; set; }
    public int IdTipoEstadoFK { get; set; }
    public TipoEstado TipoEstado { get; set; }
    public ICollection<Orden> Ordens { get; set; }
    public ICollection<DetalleOrden> DetalleOrdens { get; set; }
}