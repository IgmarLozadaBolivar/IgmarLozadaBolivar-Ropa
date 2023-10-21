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
}