namespace Domain.Entities;

public class Cliente : BaseEntity
{
    public int IdCliente { get; set; }
    public string Nombre { get; set; }
    public int IdTipoPersonaFK { get; set; }
    public TipoPersona TipoPersona { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int IdMunicipioFK { get; set; }
    public Municipio Municipio { get; set; }
    public ICollection<Venta> Ventas { get; set; }
    public ICollection<Orden> Ordens { get; set; }
}