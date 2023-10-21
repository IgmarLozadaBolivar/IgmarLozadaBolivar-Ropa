using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class MunicipioRepo : GenericRepo<Municipio>, IMunicipio
{
    protected readonly DbAppContext _context;

    public MunicipioRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Municipio>> GetAllAsync()
    {
        return await _context.Municipios
            .Include(p => p.Departamento)
            .ToListAsync();
    }

    public override async Task<Municipio> GetByIdAsync(int id)
    {
        return await _context.Municipios
        .Include(p => p.Departamento)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Municipio> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Municipios as IQueryable<Municipio>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToString().ToLower().Contains(search));
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
