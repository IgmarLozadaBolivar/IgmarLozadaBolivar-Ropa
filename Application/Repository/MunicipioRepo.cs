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
}
