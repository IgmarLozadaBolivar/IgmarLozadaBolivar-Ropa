namespace Domain.Entities;

public class TipoPersona : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<Cliente> Clientes { get; set; }
    public ICollection<Proveedor> Proveedors { get; set; }
}