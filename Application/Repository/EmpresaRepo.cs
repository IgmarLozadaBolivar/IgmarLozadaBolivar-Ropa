using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class EmpresaRepo : GenericRepo<Empresa>, IEmpresa
{
    protected readonly DbAppContext _context;

    public EmpresaRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Empresa>> GetAllAsync()
    {
        return await _context.Empresas
            .Include(p => p.Municipio)
            .ToListAsync();
    }

    public override async Task<Empresa> GetByIdAsync(int id)
    {
        return await _context.Empresas
        .Include(p => p.Municipio)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Empresa> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Empresas as IQueryable<Empresa>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nit.ToString().ToLower().Contains(search));
            query = query.Where(p => p.RazonSocial.ToString().ToLower().Contains(search));
            query = query.Where(p => p.RepresentanteLegal.ToString().ToLower().Contains(search));
            query = query.Where(p => p.FechaCreacion.ToString().ToLower().Contains(search));
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