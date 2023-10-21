using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class ClienteRepo : GenericRepo<Cliente>, ICliente
{
    protected readonly DbAppContext _context;

    public ClienteRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes
            .Include(p => p.TipoPersona)
            .Include(p => p.Municipio)
            .ToListAsync();
    }

    public override async Task<Cliente> GetByIdAsync(int id)
    {
        return await _context.Clientes
        .Include(p => p.TipoPersona)
        .Include(p => p.Municipio)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}