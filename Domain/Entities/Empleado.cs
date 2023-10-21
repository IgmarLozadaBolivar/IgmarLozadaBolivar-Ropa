namespace Domain.Entities;

public class Empleado : BaseEntity
{
    public int IdEmpleado { get; set; }
    public string Nombre { get; set; }
    public int IdCargoFK { get; set; }
    public Cargo Cargo { get; set; }
    public DateTime FechaIngreso { get; set; }
    public int IdMunicipioFK { get; set; }
    public Municipio Municipio { get; set; }
    public ICollection<Venta> Ventas { get; set; }
    public ICollection<Orden> Ordens { get; set; }
}