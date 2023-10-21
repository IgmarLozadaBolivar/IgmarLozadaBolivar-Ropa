using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class ClienteRepo : GenericRepo<Cliente>, ICliente
{
    protected readonly DbAppContext _context;

    public ClienteRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes
            .Include(p => p.TipoPersona)
            .Include(p => p.Municipio)
            .ToListAsync();
    }

    public override async Task<Cliente> GetByIdAsync(int id)
    {
        return await _context.Clientes
        .Include(p => p.TipoPersona)
        .Include(p => p.Municipio)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Cliente> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Clientes as IQueryable<Cliente>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.IdCliente.ToString().ToLower().Contains(search));
            query = query.Where(p => p.Nombre.ToString().ToLower().Contains(search));
            query = query.Where(p => p.FechaRegistro.ToString().ToLower().Contains(search));
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