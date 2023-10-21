using Domain.Entities;
namespace API.Dtos;

public class ProveedorDto : BaseEntity
{
    public int NitProveedor { get; set; }
    public string Nombre { get; set; }
    public int IdTipoPersonaFK { get; set; }
    public int IdMunicipioFK { get; set; }
}