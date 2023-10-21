using Domain.Entities;
namespace API.Dtos;

public class VentaDto : BaseEntity
{
    public DateOnly Fecha { get; set; }
    public int IdEmpleadoFK { get; set; }
    public int IdClienteFK { get; set; }
    public int IdFormaPagoFK { get; set; }
}