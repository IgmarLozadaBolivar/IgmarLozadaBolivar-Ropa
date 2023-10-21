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

    public override async Task<(int totalRegistros, IEnumerable<TipoProteccion> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.TipoProteccions as IQueryable<TipoProteccion>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Descripcion.ToString().ToLower().Contains(search));
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