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
}