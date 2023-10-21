using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class FormaPagoRepo : GenericRepo<FormaPago>, IFormaPago
{
    protected readonly DbAppContext _context;

    public FormaPagoRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<FormaPago>> GetAllAsync()
    {
        return await _context.FormaPagos
            .ToListAsync();
    }

    public override async Task<FormaPago> GetByIdAsync(int id)
    {
        return await _context.FormaPagos
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}