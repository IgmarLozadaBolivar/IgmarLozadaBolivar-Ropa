namespace Domain.Entities;

public class Orden : BaseEntity
{
    public DateOnly Fecha { get; set; }
    public int IdEmpleadoFK { get; set; }
    public Empleado Empleado { get; set; }
    public int IdClienteFK { get; set; }
    public Cliente Cliente { get; set; }
    public int IdEstadoFK { get; set; }
    public Estado Estado { get; set; }
    public ICollection<DetalleOrden> DetalleOrdens { get; set; }
}