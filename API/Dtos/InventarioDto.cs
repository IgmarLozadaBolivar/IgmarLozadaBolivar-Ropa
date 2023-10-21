using Domain.Entities;
namespace API.Dtos;

public class InventarioDto : BaseEntity
{
    public int CodInv { get; set; }
    public int IdPrendaFK { get; set; }
    public Prenda Prenda { get; set; }
    public decimal ValorVtaCOP { get; set; }
    public decimal ValorVtaUSD { get; set; }
}