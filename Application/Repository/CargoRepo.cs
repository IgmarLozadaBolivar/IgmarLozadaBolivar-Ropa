using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class CargoRepo : GenericRepo<Cargo>, ICargo
{
    protected readonly DbAppContext _context;

    public CargoRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Cargo>> GetAllAsync()
    {
        return await _context.Cargos
            .ToListAsync();
    }

    public override async Task<Cargo> GetByIdAsync(int id)
    {
        return await _context.Cargos
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}