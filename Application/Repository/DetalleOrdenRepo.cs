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
}