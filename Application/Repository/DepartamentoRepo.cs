using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class DepartamentoRepo : GenericRepo<Departamento>, IDepartamento
{
    protected readonly DbAppContext _context;

    public DepartamentoRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Departamento>> GetAllAsync()
    {
        return await _context.Departamentos
            .Include(p => p.Pais)
            .ToListAsync();
    }

    public override async Task<Departamento> GetByIdAsync(int id)
    {
        return await _context.Departamentos
        .Include(p => p.Pais)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}