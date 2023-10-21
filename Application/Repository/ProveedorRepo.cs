using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class ProveedorRepo : GenericRepo<Proveedor>, IProveedor
{
    protected readonly DbAppContext _context;

    public ProveedorRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _context.Proveedors
            .Include(p => p.TipoPersona)
            .Include(p => p.Municipio)
            .ToListAsync();
    }

    public override async Task<Proveedor> GetByIdAsync(int id)
    {
        return await _context.Proveedors
        .Include(p => p.TipoPersona)
        .Include(p => p.Municipio)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}