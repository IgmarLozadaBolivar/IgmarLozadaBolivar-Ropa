using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class TipoPersonaRepo : GenericRepo<TipoPersona>, ITipoPersona
{
    protected readonly DbAppContext _context;

    public TipoPersonaRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TipoPersona>> GetAllAsync()
    {
        return await _context.TipoPersonas
            .ToListAsync();
    }

    public override async Task<TipoPersona> GetByIdAsync(int id)
    {
        return await _context.TipoPersonas
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}