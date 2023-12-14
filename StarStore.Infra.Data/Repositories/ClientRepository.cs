using Microsoft.EntityFrameworkCore;
using StarStore.Domain.Entities;
using StarStore.Domain.Interfaces;
using StarStore.Infra.Data.Context;

namespace StarStore.Infra.Data.Repositories;

public class ClientRepository : GenericRepository<Client>, IClientRepository
{
    private readonly ApplicationDbContext _context;
    public ClientRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Client> GetClientById(Guid id)
    {
        return await _context.Clients
                        .AsNoTracking()
                        .FirstOrDefaultAsync(c => c.Active && 
                                                    c.Id == id);
    }
}
