using StarStore.Application.DTOs;

namespace StarStore.Application.Interfaces;

public interface IClientService
{
    Task<ClientDto> GetClientById(Guid id);
    Task<ClientDto> Create(ClientDto model);
    Task<ClientDto> Update(ClientDto model);
    Task<ClientDto> Delete(Guid id);
}
