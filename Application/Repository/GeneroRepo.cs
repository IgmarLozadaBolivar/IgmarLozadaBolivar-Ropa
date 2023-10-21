using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class GeneroRepo : GenericRepo<Genero>, IGenero
{
    protected readonly DbAppContext _context;

    public GeneroRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Genero>> GetAllAsync()
    {
        return await _context.Generos
            .ToListAsync();
    }

    public override async Task<Genero> GetByIdAsync(int id)
    {
        return await _context.Generos
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}