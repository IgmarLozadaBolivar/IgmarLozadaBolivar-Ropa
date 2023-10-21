using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class EmpleadoRepo : GenericRepo<Empleado>, IEmpleado
{
    protected readonly DbAppContext _context;

    public EmpleadoRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public async Task<object> Cargos()
    {
        return await _context.Empleados
        .Include(p => p.Cargo)
        .Where(p => p.Cargo.Descripcion == "Cajero")
        .ToListAsync();
    }

    public override async Task<IEnumerable<Empleado>> GetAllAsync()
    {
        return await _context.Empleados
            .Include(p => p.Cargo)
            .Include(p => p.Municipio)
            .ToListAsync();
    }

    public override async Task<Empleado> GetByIdAsync(int id)
    {
        return await _context.Empleados
        .Include(p => p.Cargo)
        .Include(p => p.Municipio)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Empleado> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Empleados as IQueryable<Empleado>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.IdEmpleado.ToString().ToLower().Contains(search));
            query = query.Where(p => p.Nombre.ToString().ToLower().Contains(search));
            query = query.Where(p => p.FechaIngreso.ToString().ToLower().Contains(search));
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