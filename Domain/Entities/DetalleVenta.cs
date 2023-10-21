namespace Domain.Entities;

public class DetalleVenta : BaseEntity
{
    public int IdVentaFK { get; set; }
    public Venta Venta { get; set; }
    public int IdProductoFK { get; set; }
    public Inventario Inventario { get; set; }
    public int IdTallaFK { get; set; }
    public Talla Talla { get; set; }
    public int Cantidad { get; set; }
    public decimal ValorUnit { get; set; }
}