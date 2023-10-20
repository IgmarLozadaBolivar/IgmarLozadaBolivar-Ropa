namespace Domain.Entities;

public class Venta : BaseEntity
{
    public DateOnly Fecha { get; set; }
    public int IdEmpleadoFK { get; set; }
    public Empleado Empleado { get; set; }
    public int IdClienteFK { get; set; }
    public Cliente Cliente { get; set; }
    public int IdFormaPagoFK { get; set; }
    public FormaPago FormaPago { get; set; }
    public ICollection<DetalleVenta> DetalleVentas { get; set; }
}