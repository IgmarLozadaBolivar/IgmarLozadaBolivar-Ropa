using Domain.Entities;
namespace API.Dtos;

public class EmpresaDto : BaseEntity
{
    public int Nit { get; set; }
    public string RazonSocial { get; set; }
    public string RepresentanteLegal { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int IdMunicipioFK { get; set; }
}