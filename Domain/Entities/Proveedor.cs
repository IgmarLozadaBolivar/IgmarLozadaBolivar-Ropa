namespace Domain.Entities;

public class Proveedor : BaseEntity
{
    public string NitProveedor { get; set; }
    public string Nombre { get; set; }
    public int IdTipoPersonaFK { get; set; }
    public TipoPersona TipoPersona { get; set; }
    public int IdMunicipioFK { get; set; }
    public Municipio Municipio { get; set; }
    public ICollection<InsumoProveedor> InsumoProveedors { get; set; } = new HashSet<InsumoProveedor>();
}