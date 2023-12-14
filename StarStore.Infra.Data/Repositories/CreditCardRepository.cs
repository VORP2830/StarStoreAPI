using StarStore.Domain.Entities;
using StarStore.Domain.Interfaces;
using StarStore.Infra.Data.Context;

namespace StarStore.Infra.Data.Repositories;
public class CreditCardRepository : GenericRepository<CreditCard>, ICreditCardRepository
{
    private readonly ApplicationDbContext _context;
    public CreditCardRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
