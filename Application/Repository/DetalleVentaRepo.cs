using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class DetalleVentaRepo : GenericRepo<DetalleVenta>, IDetalleVenta
{
    protected readonly DbAppContext _context;

    public DetalleVentaRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<DetalleVenta>> GetAllAsync()
    {
        return await _context.DetalleVentas
            .Include(p => p.Venta)
            .Include(p => p.Inventario)
            .Include(p => p.Talla)
            .ToListAsync();
    }

    public override async Task<DetalleVenta> GetByIdAsync(int id)
    {
        return await _context.DetalleVentas
        .Include(p => p.Venta)
        .Include(p => p.Inventario)
        .Include(p => p.Talla)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<DetalleVenta> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.DetalleVentas as IQueryable<DetalleVenta>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Cantidad.ToString().ToLower().Contains(search));
            query = query.Where(p => p.ValorUnit.ToString().ToLower().Contains(search));
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