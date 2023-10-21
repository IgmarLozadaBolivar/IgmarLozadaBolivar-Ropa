using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class PrendaRepo : GenericRepo<Prenda>, IPrenda
{
    protected readonly DbAppContext _context;

    public PrendaRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Prenda>> GetAllAsync()
    {
        return await _context.Prendas
            .Include(p => p.Estado)
            .Include(p => p.TipoProteccion)
            .Include(p => p.Genero)
            .ToListAsync();
    }

    public override async Task<Prenda> GetByIdAsync(int id)
    {
        return await _context.Prendas
        .Include(p => p.Estado)
        .Include(p => p.TipoProteccion)
        .Include(p => p.Genero)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}