using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class CargoRepo : GenericRepo<Cargo>, ICargo
{
    protected readonly DbAppContext _context;

    public CargoRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Cargo>> GetAllAsync()
    {
        return await _context.Cargos
            .ToListAsync();
    }

    public override async Task<Cargo> GetByIdAsync(int id)
    {
        return await _context.Cargos
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Cargo> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Cargos as IQueryable<Cargo>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Descripcion.ToString().ToLower().Contains(search));
            query = query.Where(p => p.SueldoBase.ToString().ToLower().Contains(search));
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