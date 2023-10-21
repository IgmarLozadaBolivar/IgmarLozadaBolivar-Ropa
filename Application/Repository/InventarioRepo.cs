using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class InventarioRepo : GenericRepo<Inventario>, IInventario
{
    protected readonly DbAppContext _context;

    public InventarioRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Inventario>> GetAllAsync()
    {
        return await _context.Inventarios
            .Include(p => p.Prenda)
            .ToListAsync();
    }

    public override async Task<Inventario> GetByIdAsync(int id)
    {
        return await _context.Inventarios
        .Include(p => p.Prenda)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}