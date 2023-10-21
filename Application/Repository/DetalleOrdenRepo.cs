using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class DetalleOrdenRepo : GenericRepo<DetalleOrden>, IDetalleOrden
{
    protected readonly DbAppContext _context;

    public DetalleOrdenRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<DetalleOrden>> GetAllAsync()
    {
        return await _context.DetalleOrdens
            .Include(p => p.Orden)
            .Include(p => p.Prenda)
            .Include(p => p.Color)
            .Include(p => p.Estado)
            .ToListAsync();
    }

    public override async Task<DetalleOrden> GetByIdAsync(int id)
    {
        return await _context.DetalleOrdens
        .Include(p => p.Orden)
        .Include(p => p.Prenda)
        .Include(p => p.Color)
        .Include(p => p.Estado)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<DetalleOrden> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.DetalleOrdens as IQueryable<DetalleOrden>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.CantidadProduccir.ToString().ToLower().Contains(search));
            query = query.Where(p => p.CantidadProducida.ToString().ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
}