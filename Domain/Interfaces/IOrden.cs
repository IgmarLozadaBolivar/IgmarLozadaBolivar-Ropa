using Domain.Entities;
namespace Domain.Interfaces;

public interface IOrden : IGenericRepo<Orden>
{
    Task<IEnumerable<Orden>> OrdenesEnProceso();
}