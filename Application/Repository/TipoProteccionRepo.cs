using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class TipoProteccionRepo : GenericRepo<TipoProteccion>, ITipoProteccion
{
    protected readonly DbAppContext _context;

    public TipoProteccionRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TipoProteccion>> GetAllAsync()
    {
        return await _context.TipoProteccions
            .ToListAsync();
    }

    public override async Task<TipoProteccion> GetByIdAsync(int id)
    {
        return await _context.TipoProteccions
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}