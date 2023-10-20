namespace Domain.Entities;

public class InsumoProveedor
{
    public int IdInsumoFK { get; set; }
    public Insumo Insumo { get; set; }
    public int IdProveedorFK { get; set; }
    public Proveedor Proveedor { get; set; }
}