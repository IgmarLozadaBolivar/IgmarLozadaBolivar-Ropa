using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class OrdenRepo : GenericRepo<Orden>, IOrden
{
    protected readonly DbAppContext _context;

    public OrdenRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Orden>> GetAllAsync()
    {
        return await _context.Ordens
            .Include(p => p.Empleado)
            .Include(p => p.Cliente)
            .Include(p => p.Estado)
            .ToListAsync();
    }

    public override async Task<Orden> GetByIdAsync(int id)
    {
        return await _context.Ordens
        .Include(p => p.Empleado)
        .Include(p => p.Cliente)
        .Include(p => p.Estado)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public virtual async Task<IEnumerable<Orden>> OrdenesEnProceso()
    {
        /* var ordenesEnProduccion = await (
            from m in _context.Ordens
            join r in _context.Estados on m.IdEstadoFK equals r.Id
            join e in _context.Estados on r.IdTipoEstadoFK equals e.Id
            where e.Descripcion.Contains("En Proceso")
            select m
        ).Distinct().ToListAsync();

        return ordenesEnProduccion; */

        return await _context.Ordens
            .Include(p => p.Estado)
            .Where(p => p.Estado.Descripcion == "En Proceso")
            .ToListAsync();
    }
}