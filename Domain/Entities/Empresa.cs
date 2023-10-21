using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Empresa : BaseEntity
{
    public int Nit { get; set; }
    public string RazonSocial { get; set; }
    public string RepresentanteLegal { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int IdMunicipioFK { get; set; }
    public Municipio Municipio { get; set; }
}