using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class ColorRepo : GenericRepo<Color>, IColor
{
    protected readonly DbAppContext _context;

    public ColorRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Color>> GetAllAsync()
    {
        return await _context.Colors
            .ToListAsync();
    }

    public override async Task<Color> GetByIdAsync(int id)
    {
        return await _context.Colors
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}