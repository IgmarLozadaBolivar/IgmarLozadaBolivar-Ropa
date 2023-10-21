using Domain.Entities;
namespace API.Dtos;

public class DetalleOrdenDto : BaseEntity
{
    public int IdOrdenFK { get; set; }
    public int IdPrendaFK { get; set; }
    public int CantidadProduccir { get; set; }
    public int IdColorFK { get; set; }
    public int CantidadProducida { get; set; }
    public int IdEstadoFK { get; set; }
}