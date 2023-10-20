namespace Domain.Entities;

public class InventarioTalla
{
    public int IdInventarioFK { get; set; }
    public Inventario Inventario { get; set; }
    public int IdTallaFK { get; set; }
    public Talla Talla { get; set; }
    public int Cantidad { get; set; }
}