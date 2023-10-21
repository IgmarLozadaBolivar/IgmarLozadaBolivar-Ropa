using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class TallaRepo : GenericRepo<Talla>, ITalla
{
    protected readonly DbAppContext _context;

    public TallaRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Talla>> GetAllAsync()
    {
        return await _context.Tallas
            .ToListAsync();
    }

    public override async Task<Talla> GetByIdAsync(int id)
    {
        return await _context.Tallas
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Talla> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Tallas as IQueryable<Talla>;

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