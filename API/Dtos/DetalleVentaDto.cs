using Domain.Entities;
namespace API.Dtos;

public class DetalleVentaDto : BaseEntity
{
    public int IdVentaFK { get; set; }
    public int IdProductoFK { get; set; }
    public int IdTallaFK { get; set; }
    public int Cantidad { get; set; }
    public decimal ValorUnit { get; set; }
}