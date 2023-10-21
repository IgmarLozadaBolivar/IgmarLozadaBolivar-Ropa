using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class InsumoRepo : GenericRepo<Insumo>, IInsumo
{
    protected readonly DbAppContext _context;

    public InsumoRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Insumo>> GetAllAsync()
    {
        return await _context.Insumos
            .ToListAsync();
    }

    public override async Task<Insumo> GetByIdAsync(int id)
    {
        return await _context.Insumos
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}