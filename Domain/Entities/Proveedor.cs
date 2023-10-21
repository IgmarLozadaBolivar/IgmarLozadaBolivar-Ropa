namespace Domain.Entities;

public class Proveedor : BaseEntity
{
    public int NitProveedor { get; set; }
    public string Nombre { get; set; }
    public int IdTipoPersonaFK { get; set; }
    public TipoPersona TipoPersona { get; set; }
    public int IdMunicipioFK { get; set; }
    public Municipio Municipio { get; set; }
    public ICollection<Insumo> Insumos { get; set; } = new HashSet<Insumo>();
    public ICollection<InsumoProveedor> InsumoProveedors { get; set; } = new HashSet<InsumoProveedor>();
}