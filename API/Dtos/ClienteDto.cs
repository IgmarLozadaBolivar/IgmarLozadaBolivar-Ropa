using Domain.Entities;
namespace API.Dtos;

public class ClienteDto : BaseEntity
{
    public int IdCliente { get; set; }
    public string Nombre { get; set; }
    public int IdTipoPersonaFK { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int IdMunicipioFK { get; set; }
}