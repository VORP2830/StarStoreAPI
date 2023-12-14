using StarStore.Domain.Entities;

namespace StarStore.Domain.Interfaces;

public interface IClientRepository : IGenericRepository<Client>
{
    Task<Client> GetClientById(Guid id);
}
