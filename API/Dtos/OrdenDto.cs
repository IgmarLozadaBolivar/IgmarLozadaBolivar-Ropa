using Domain.Entities;
namespace API.Dtos;

public class OrdenDto : BaseEntity
{
    public DateOnly Fecha { get; set; }
    public int IdEmpleadoFK { get; set; }
    public int IdClienteFK { get; set; }
    //public int IdEstadoFK { get; set; }
    public List<EstadoDto> estados { get; set; }
}