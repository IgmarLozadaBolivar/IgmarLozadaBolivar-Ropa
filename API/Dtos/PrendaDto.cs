using Domain.Entities;
namespace API.Dtos;

public class PrendaDto : BaseEntity
{
    public int IdPrenda { get; set; }
    public string Nombre { get; set; }
    public decimal ValorUnitCOP { get; set; }
    public decimal ValorUnitUSD { get; set; }
    public int IdEstadoFK { get; set; }
    public int IdTipoProteccionFK { get; set; }
    public int IdGeneroFK { get; set; }
}