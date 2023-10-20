namespace Domain.Entities;

public class DetalleOrden : BaseEntity
{
    public int IdOrdenFK { get; set; }
    public Orden Orden { get; set; }
    public int IdPrendaFK { get; set; }
    public Prenda Prenda { get; set; }
    public int CantidadProduccir { get; set; }
    public int IdColorFK { get; set; }
    public Color Color { get; set; }
    public int CantidadProducida { get; set; }
    public int IdEstadoFK { get; set; }
    public Estado Estado { get; set; }
}