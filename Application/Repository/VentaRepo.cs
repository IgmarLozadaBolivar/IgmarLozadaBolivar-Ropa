using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class VentaRepo : GenericRepo<Venta>, IVenta
{
    protected readonly DbAppContext _context;

    public VentaRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Venta>> GetAllAsync()
    {
        return await _context.Ventas
            .Include(p => p.Empleado)
            .Include(p => p.Cliente)
            .Include(p => p.FormaPago)
            .ToListAsync();
    }

    public override async Task<Venta> GetByIdAsync(int id)
    {
        return await _context.Ventas
        .Include(p => p.Empleado)
        .Include(p => p.Cliente)
        .Include(p => p.FormaPago)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Venta> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Ventas as IQueryable<Venta>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Fecha.ToString().ToLower().Contains(search));
            query = query.Where(p => p.Empleado.ToString().ToLower().Contains(search));
            query = query.Where(p => p.Cliente.ToString().ToLower().Contains(search));
            query = query.Where(p => p.FormaPago.ToString().ToLower().Contains(search));
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