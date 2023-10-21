using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class EstadoRepo : GenericRepo<Estado>, IEstado
{
    protected readonly DbAppContext _context;

    public EstadoRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Estado>> GetAllAsync()
    {
        return await _context.Estados
            .Include(p => p.TipoEstado)
            .ToListAsync();
    }

    public override async Task<Estado> GetByIdAsync(int id)
    {
        return await _context.Estados
        .Include(p => p.TipoEstado)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}