using Domain.Entities;
namespace API.Dtos;

public class DepartamentoDto : BaseEntity
{
    public string Nombre { get; set; }
    public int IdPaisFK { get; set; }
}