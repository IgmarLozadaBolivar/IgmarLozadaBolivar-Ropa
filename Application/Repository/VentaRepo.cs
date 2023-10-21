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
}