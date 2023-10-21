using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class PaisRepo : GenericRepo<Pais>, IPais
{
    protected readonly DbAppContext _context;

    public PaisRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Pais>> GetAllAsync()
    {
        return await _context.Paises
            .ToListAsync();
    }

    public override async Task<Pais> GetByIdAsync(int id)
    {
        return await _context.Paises
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}