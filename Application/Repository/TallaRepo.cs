using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class TallaRepo : GenericRepo<Talla>, ITalla
{
    protected readonly DbAppContext _context;

    public TallaRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Talla>> GetAllAsync()
    {
        return await _context.Tallas
            .ToListAsync();
    }

    public override async Task<Talla> GetByIdAsync(int id)
    {
        return await _context.Tallas
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}