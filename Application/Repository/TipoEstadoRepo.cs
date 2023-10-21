
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class TipoEstadoRepo : GenericRepo<TipoEstado>, ITipoEstado
{
    protected readonly DbAppContext _context;

    public TipoEstadoRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TipoEstado>> GetAllAsync()
    {
        return await _context.TipoEstados
            .ToListAsync();
    }

    public override async Task<TipoEstado> GetByIdAsync(int id)
    {
        return await _context.TipoEstados
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}