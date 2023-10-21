using Domain.Entities;
namespace API.Dtos;

public class InsumoDto : BaseEntity
{
    public string Nombre { get; set; }
    public decimal ValorUnit { get; set; }
    public int StockMin { get; set; }
    public int StockMax { get; set; }
}